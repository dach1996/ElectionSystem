using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Mail;
using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Models.Response.User;
using Dach.ElectionSystem.Repository.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.User
{
    public class UserCreateHandler : IRequestHandler<UserCreateRequest, UserCreateResponse>
    {
        #region Constructor
        private readonly ILogger<UserCreateHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IElectionUnitOfWork _electionUnitOfWork;
        private readonly Services.Notification.INotification _notification;


        public UserCreateHandler(
            ILogger<UserCreateHandler> logger,
            IMapper mapper,
            IConfiguration configuration,
            Services.Notification.INotification notification,
            IElectionUnitOfWork electionUnitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _configuration = configuration;
            _notification = notification;
            _electionUnitOfWork = electionUnitOfWork;
        }
        #endregion

        #region Handler
        public async Task<UserCreateResponse> Handle(UserCreateRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                try
                {
                    await _electionUnitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                    var _secretKey = _configuration.GetSection("SecretKey").Value;
                    //Hash a la clave
                    var passwordOriginal = request.Password;
                    request.Password = Common.Util.ComputeSHA256(request.Password, _secretKey);
                    //Valida que el usuario exista
                    var emailExist = await _electionUnitOfWork.GetUserRepository().GetAsync(u => u.Email == request.Email);
                    if (emailExist.Any())
                        throw new CustomException(Models.Enums.MessageCodesApi.EmailRegistered, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
                    var userNew = _mapper.Map<Models.Persitence.User>(request);
                    var numberEventsString = _configuration.GetSection("NumberEventsToCreate").Value;
                    _ = int.TryParse(numberEventsString, out var numberEvents);
                    userNew.EventNumber = new Models.Persitence.EventNumber()
                    {
                        User = userNew,
                        NumberMaxEvent = numberEvents
                    };
                    userNew.IsActive = true;
                    var isRegister = await _electionUnitOfWork.GetUserRepository().CreateAsync(userNew);
                    if (!isRegister)
                        throw new CustomException(Models.Enums.MessageCodesApi.NotCreateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    //Preparamos para envíar correo
                    var templates = _configuration.GetSection("SendgridConfiguration:Templates").Get<Template[]>();
                    var templateForggotenPassword = templates.FirstOrDefault(t => t.TemplateName == Models.Static.Template.UserWelcome);
                    bool isSend = SendEmail(request, passwordOriginal, userNew, templateForggotenPassword);
                    if (!isSend)
                         _logger.LogWarning($"No se pudo Envíar correo: {userNew.Email}");
                    await _electionUnitOfWork.CommitAsync().ConfigureAwait(false);
                    return _mapper.Map<UserCreateResponse>(userNew);
                }
                catch (System.Exception)
                {
                    await _electionUnitOfWork.RollBackAsync().ConfigureAwait(false);
                    throw;
                }
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Enviar Email
        /// </summary>
        /// <param name="request"></param>
        /// <param name="passwordOriginal"></param>
        /// <param name="userNew"></param>
        /// <param name="templateForggotenPassword"></param>
        /// <returns></returns>
        private bool SendEmail(UserCreateRequest request, string passwordOriginal, Models.Persitence.User userNew, Template templateForggotenPassword)
        {
            return _notification.SendMail(
                                    new MailModel()
                                    {
                                        Subject = templateForggotenPassword.TemplateName,
                                        To = new List<string>() { request.Email },
                                        Template = templateForggotenPassword.TemplateKey,
                                        Params = new
                                        {
                                            Fullname = $"{userNew.FirstName} {userNew.FirstLastName}",
                                            Username = userNew.Email,
                                            Password = passwordOriginal
                                        }
                                    }
                                );
        }
        #endregion
    }
}
