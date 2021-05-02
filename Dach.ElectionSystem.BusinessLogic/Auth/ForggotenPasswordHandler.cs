using System.Linq;
using Dach.ElectionSystem.Models.Auth;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Services.TokenJWT;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.Auth
{

    public class ForggotenPasswordHandler : IRequestHandler<ForggotenPasswordRequest, Unit>
    {
        #region Constructor
        private readonly Services.Notification.INotification notification;
        private readonly string _secretKey;
        private readonly IUserRepository _usuarioRepository;

        public ForggotenPasswordHandler(
            IUserRepository usuarioRepository,
            IConfiguration configuration,
           Services.Notification.INotification notification)
        {
            _usuarioRepository = usuarioRepository;
            this.notification = notification;
            _secretKey = configuration.GetSection("SecretKey").Value;
        }

        #endregion
        public async Task<Unit> Handle(ForggotenPasswordRequest request, CancellationToken cancellationToken)
        {
            var newPasswordGenerate = Common.Util.GenerateCode(15);
            var passwordHash = Common.Util.ComputeSHA256(newPasswordGenerate, _secretKey);
            var user = (await _usuarioRepository.GetAsync(u => u.Email == request.Email)).FirstOrDefault();
            if (user == null)
                throw new CustomException(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Unauthorized);
            user.TemPassword = passwordHash;
            var isUpdate = await _usuarioRepository.Update(user);
            if (!isUpdate)
                throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            var isSend = notification.SendMail(
                new Models.Mail.MailModel()
                {
                    From = "electionsystemec@gmail.com",
                    Subject = "Recuperar Contraseña",
                    To = request.Email,
                    Template = "d-547cb7b55c5e4924b4a939227abf1e50",
                    Params = new { Username = $"{user.FirstName} {user.FirstLastName}", Password = newPasswordGenerate }
                }
            );
            if (!isSend)
                throw new CustomException(Models.Enums.MessageCodesApi.MailError, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);

            return Unit.Value;
        }
    }
}
