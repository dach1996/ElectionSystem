using System.Linq;
using Dach.ElectionSystem.Models.Auth;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Repository.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;
using Dach.ElectionSystem.Models.Mail;
using System.Collections.Generic;

namespace Dach.ElectionSystem.BusinessLogic.Auth
{

    public class ForggotenPasswordHandler : IRequestHandler<ForggotenPasswordRequest, Unit>
    {
        #region Constructor
        private readonly Services.Notification.INotification notification;
        private readonly string _secretKey;
        private readonly IUserRepository _usuarioRepository;
        private readonly IConfiguration configuration;

        public ForggotenPasswordHandler(
            IUserRepository usuarioRepository,
            IConfiguration configuration,
            Services.Notification.INotification notification)
        {
            _usuarioRepository = usuarioRepository;
            this.configuration = configuration;
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
            //Preparamos para envíar correo
            var templates =  configuration.GetSection("SendgridConfiguration:Templates").Get<Template[]>();
            var templateForggotenPassword = templates.FirstOrDefault(t => t.TemplateName== Models.Static.Template.ForggotenPass);
            var isSend = notification.SendMail(
                new MailModel()
                {
                    Subject = templateForggotenPassword.TemplateName,
                    To = new List<string>(){request.Email},
                    Template = templateForggotenPassword.TemplateKey,
                    Params = new { Username = $"{user.FirstName} {user.FirstLastName}", Password = newPasswordGenerate }
                }
            );
            if (!isSend)
                throw new CustomException(Models.Enums.MessageCodesApi.MailError, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);

            return Unit.Value;
        }
    }
}
