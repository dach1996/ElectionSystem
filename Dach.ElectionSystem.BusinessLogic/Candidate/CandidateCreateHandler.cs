using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Response.Candidate;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dach.ElectionSystem.Models.Mail;
using System.Collections.Generic;
using Dach.ElectionSystem.Repository.UnitOfWork;
using System;

namespace Dach.ElectionSystem.BusinessLogic.Candidate
{
    public class CandidateCreateHandler : IRequestHandler<CandidateCreateRequest, CandidateCreateResponse>
    {
        #region Constructor
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity _validateIntegrity;
        private readonly IConfiguration _configuration;
        private readonly Services.Notification.INotification _notification;
        private readonly ILogger<CandidateCreateHandler> _logger;
        private readonly IElectionUnitOfWork _electionUnitOfWork;

        public CandidateCreateHandler(
            IMapper mapper,
            ValidateIntegrity validateIntegrity,
            IConfiguration configuration,
            Services.Notification.INotification notification,
            ILogger<CandidateCreateHandler> logger,
            IElectionUnitOfWork electionUnitOfWork)
        {
            _mapper = mapper;
            _validateIntegrity = validateIntegrity;
            _configuration = configuration;
            _notification = notification;
            _logger = logger;
            _electionUnitOfWork = electionUnitOfWork;
        }
        #endregion

        #region Handler
        public async Task<CandidateCreateResponse> Handle(CandidateCreateRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                try
                {
                    await _electionUnitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                    //Valida que el evento exista
                    var eventCurrent = await _validateIntegrity.ValidateEvent(request.IdEvent);
                    //Valida el Número máximo de candidatas creadas
                    if (eventCurrent.NumberMaxCandidate <= eventCurrent.ListCandidate.Count(c=>c.IsActive))
                        throw new CustomException(Models.Enums.MessageCodesApi.MaxCandidateRegister, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
                    //Valida que el usuario sea administrador del evento
                    var userCurrent = await _validateIntegrity.ValidateUser(request.IdUser);
                    var isUserCurrentAdministrator = request.UserContext.ListEventAdministrator.Any(e => e.IdEvent == eventCurrent.Id);
                    if (!isUserCurrentAdministrator)
                        throw new CustomException(Models.Enums.MessageCodesApi.UserIsnotAdministratorEvent, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
                    //Valida que el usuario no esté registrado ya como candidato del evento
                    var hasRegisterCandidate = eventCurrent.ListCandidate.Any(c => c.IdUser == userCurrent.Id);
                    if (hasRegisterCandidate)
                        throw new CustomException(Models.Enums.MessageCodesApi.IsCandidateInEvent, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.NotFound);
                    //Validar que el evento no haya empezado ni terminado
                    await _validateIntegrity.ValidateEventStateNotStarterNotFinished(eventCurrent.Id).ConfigureAwait(false);
                    //Creamos el nuevo Candidato
                    var newCandidate = _mapper.Map<Models.Persitence.Candidate>(request);
                    var isCreate = await _electionUnitOfWork.GetCandidateRepository().CreateAsync(newCandidate);
                    if (!isCreate)
                        throw new CustomException(Models.Enums.MessageCodesApi.NotCreateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    //Preparamos para envíar correo
                    var templates = _configuration.GetSection("SendgridConfiguration:Templates").Get<Template[]>();
                    var templateNewCandidate = templates.FirstOrDefault(t => t.TemplateName == Models.Static.Template.NewCandidate);
                    bool isSend = SendMail(eventCurrent, userCurrent, templateNewCandidate);
                    if (!isSend)
                        _logger.LogWarning($"No se pudo Envíar correo: {userCurrent.Email}");
                    var response = _mapper.Map<CandidateCreateResponse>(newCandidate);
                    await _electionUnitOfWork.CommitAsync().ConfigureAwait(false);
                    return response;
                }
                catch (Exception)
                {
                    await _electionUnitOfWork.RollBackAsync().ConfigureAwait(false);
                    throw;
                }
            }

        }

        private bool SendMail(Models.Persitence.Event eventCurrent, Models.Persitence.User userCurrent, Template templateNewCandidate)
        {
            return _notification.SendMail(
                new MailModel()
                {
                    Subject = templateNewCandidate.TemplateName,
                    To = new List<string>() { userCurrent.Email },
                    Template = templateNewCandidate.TemplateKey,
                    Params = new
                    {
                        EventName = eventCurrent.Name,
                        Fullname = $"{userCurrent.FirstName} {userCurrent.FirstLastName}",
                        DateMinVote = eventCurrent.DateMaxRegisterParticipants.ToString("dd/MM/yyyy")
                    }
                }
            );
        }
        #endregion

    }
}
