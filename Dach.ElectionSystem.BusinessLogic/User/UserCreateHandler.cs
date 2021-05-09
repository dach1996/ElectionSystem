using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Mail;
using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Models.Response.User;
using Dach.ElectionSystem.Repository.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.User
{
    public class UserCreateHandler : IRequestHandler<UserCreateRequest, UserCreateResponse>
    {
        #region Constructor
        private readonly ILogger<UserCreateHandler> logger;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly IConfiguration _configuration;
        private readonly Services.Notification.INotification notification;

        public UserCreateHandler(
            ILogger<UserCreateHandler> logger,
            IUserRepository userRepository,
            IMapper mapper,
            IConfiguration configuration,
            Services.Notification.INotification notification)
        {
            this.logger = logger;
            this.userRepository = userRepository;
            this.mapper = mapper;
            _configuration = configuration;
            this.notification = notification;
        }
        #endregion

        #region Handler
        public async Task<UserCreateResponse> Handle(UserCreateRequest request, CancellationToken cancellationToken)
        {
            var _secretKey = _configuration.GetSection("SecretKey").Value;
            //Hash a la clave
            var passwordOriginal = request.Password;
            request.Password = Common.Util.ComputeSHA256(request.Password, _secretKey);
            //Valida que el usuario exista
            var emailExist = await userRepository.GetAsync(u => u.Email == request.Email);
            if (emailExist.Any())
                throw new CustomException(Models.Enums.MessageCodesApi.EmailRegistered, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
            var userNew = mapper.Map<Models.Persitence.User>(request);
            userNew.EventNumber = new Models.Persitence.EventNumber()
            {
                User = userNew
            };
            userNew.IsActive = true;
            var isRegister = await userRepository.CreateAsync(userNew);
            if (!isRegister)
                throw new CustomException(Models.Enums.MessageCodesApi.NotCreateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            //Preparamos para envíar correo
            var templates = _configuration.GetSection("SendgridConfiguration:Templates").Get<Template[]>();
            var templateForggotenPassword = templates.FirstOrDefault(t => t.TemplateName == Models.Static.Template.UserWelcome);
            var isSend = notification.SendMail(
                new MailModel()
                {
                    Subject = templateForggotenPassword.TemplateName,
                    To = request.Email,
                    Template = templateForggotenPassword.TemplateKey,
                    Params = new
                    {
                        Fullname = $"{userNew.FirstName} {userNew.FirstLastName}",
                        Username = userNew.Email,
                        Password = passwordOriginal
                    }
                }
            );
            if (!isSend)
                logger.LogWarning("No se pudo Envíar correo");
            return mapper.Map<UserCreateResponse>(userNew);
        }
        #endregion
    }
}
