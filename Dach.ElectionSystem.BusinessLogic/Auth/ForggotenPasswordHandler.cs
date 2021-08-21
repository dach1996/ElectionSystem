using System.Linq;
using Dach.ElectionSystem.Models.Auth;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;
using Dach.ElectionSystem.Models.Mail;
using System.Collections.Generic;
using Dach.ElectionSystem.Repository.UnitOfWork;
using System;
using Microsoft.Extensions.Logging;

namespace Dach.ElectionSystem.BusinessLogic.Auth
{

    public class ForggotenPasswordHandler : IRequestHandler<ForggotenPasswordRequest, Unit>
    {
        #region Constructor
        private readonly Services.Notification.INotification _notification;
        private readonly string _secretKey;
        private readonly IConfiguration _configuration;
        private readonly IElectionUnitOfWork _electionUnitOfWork;
        private readonly ILogger<ForggotenPasswordHandler> _logger;

        public ForggotenPasswordHandler(
            IConfiguration configuration,
            IElectionUnitOfWork electionUnitOfWork,
            Services.Notification.INotification notification,
            ILogger<ForggotenPasswordHandler> logger)
        {
            _configuration = configuration;
            _electionUnitOfWork = electionUnitOfWork;
            _notification = notification;
            _secretKey = configuration.GetSection("SecretKey").Value;
            _logger = logger;
        }

        #endregion
        public async Task<Unit> Handle(ForggotenPasswordRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                try
                {
                    //Inicia Transacción
                    await _electionUnitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                    var newPasswordGenerate = Common.Util.GenerateCode(15);
                    var passwordHash = Common.Util.ComputeSHA256(newPasswordGenerate, _secretKey);
                    var user = (await _electionUnitOfWork.GetUserRepository().GetAsync(u => u.Email == request.Email)).FirstOrDefault();
                    if (user == null)
                        throw new CustomException(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Unauthorized);
                    user.TemPassword = passwordHash;
                    var isUpdate = await _electionUnitOfWork.GetUserRepository().Update(user);
                    if (!isUpdate)
                        throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    //Preparamos para envíar correo
                    var templates = _configuration.GetSection("SendgridConfiguration:Templates").Get<Template[]>();
                    var templateForggotenPassword = templates.FirstOrDefault(t => t.TemplateName == Models.Static.Template.ForggotenPass);
                    var isSend = _notification.SendMail(
                        new MailModel()
                        {
                            Subject = templateForggotenPassword.TemplateName,
                            To = new List<string>() { request.Email },
                            Template = templateForggotenPassword.TemplateKey,
                            Params = new { Username = $"{user.FirstName} {user.FirstLastName}", Password = newPasswordGenerate }
                        }
                    );
                    if (!isSend)
                        throw new CustomException(Models.Enums.MessageCodesApi.MailError, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    await _electionUnitOfWork.CommitAsync().ConfigureAwait(false);
                    return Unit.Value;
                }
                catch (Exception)
                {
                    await _electionUnitOfWork.RollBackAsync().ConfigureAwait(false);
                    throw;
                }
            }


        }
    }
}
