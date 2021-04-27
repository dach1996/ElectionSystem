using System.Linq;
using Dach.ElectionSystem.Models.Auth;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Response.Auth;
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
        private readonly ITokenService _tokenService;
        private readonly ILogger<AuthHandler> _logger;
        private readonly IConfiguration _configuration;
        private readonly Services.Notification.INotification notification;
        private readonly string _secretKey;
        public IMediator _mediator { get; }
        public IUserRepository _usuarioRepository { get; }

        public ForggotenPasswordHandler(IMediator mediator,
            IUserRepository usuarioRepository,
            ITokenService tokenService,
            ILogger<AuthHandler> logger,
            IConfiguration configuration,
           Services.Notification.INotification notification)
        {
            _mediator = mediator;
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
            _logger = logger;
            _configuration = configuration;
            this.notification = notification;
            _secretKey = _configuration.GetSection("SecretKey").Value;
        }

        #endregion
        public async Task<Unit> Handle(ForggotenPasswordRequest request, CancellationToken cancellationToken)
        {
            var newPasswordGenerate = Common.Util.GenerateCode(15);
            var passwordHash = Common.Util.ComputeSHA256(newPasswordGenerate, _secretKey);
            var user = (await _usuarioRepository.GetAsync(u => u.Email == request.Email)).FirstOrDefault();
            if (user == null)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Unauthorized);
            user.Password = passwordHash;
            var isUpdate = await _usuarioRepository.Update(user);
            if (!isUpdate)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
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
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.MailError, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);

            return Unit.Value;
        }
    }
}
