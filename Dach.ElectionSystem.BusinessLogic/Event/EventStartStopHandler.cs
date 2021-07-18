using System;
using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Models.Response.Event;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Dach.ElectionSystem.Repository.UnitOfWork;
using Dach.ElectionSystem.Services.Data;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Dach.ElectionSystem.Models.Mail;

namespace Dach.ElectionSystem.BusinessLogic.Event
{
    public class EventStartStopHandler : IRequestHandler<EventStartStopRequest, EventStartStopResponse>
    {
        #region Constructor 
        private readonly ILogger<EventStartStopHandler> _logger;
        private readonly IElectionUnitOfWork _electionUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity _validateIntegrity;
        private readonly IConfiguration _configuration;
        private readonly Services.Notification.INotification _notification;

        public EventStartStopHandler(
        IMapper mapper,
        IElectionUnitOfWork electionUnitOfWork,
        ILogger<EventStartStopHandler> logger,
        ValidateIntegrity validateIntegrity,
        IConfiguration configuration,
        Services.Notification.INotification notification)
        {
            _mapper = mapper;
            _electionUnitOfWork = electionUnitOfWork;
            _logger = logger;
            _validateIntegrity = validateIntegrity;
            _configuration = configuration;
            _notification = notification;
        }
        #endregion
        #region Handler
        public async Task<EventStartStopResponse> Handle(EventStartStopRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                try
                {
                    await _electionUnitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                    //Valida que el evento exista
                    var eventCurrent = await _validateIntegrity.ValidateEvent(request.IdEvent).ConfigureAwait(false);
                    //Valida que el Usuario que envía el request, sea administrtador del evento
                    await _validateIntegrity.IsCreatorEvent(request.UserContext.Id, eventCurrent.Id).ConfigureAwait(false);
                    //Valida que el evento se encuentre activado
                    if (!eventCurrent.IsActive)
                        throw new CustomException(Models.Enums.MessageCodesApi.EventIsInactive, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.NotFound,
                                                       $"El evento con id: {eventCurrent.Id} está desactivado");
                    //Valida que el evento no haya finalizado
                    if (eventCurrent.IsFinished)
                        throw new CustomException(Models.Enums.MessageCodesApi.EventIsFinished, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
                    //Valida que el evento no haya empezado
                    if (!eventCurrent.IsStarted)
                    {
                        eventCurrent.IsStarted = true;
                        eventCurrent.DateMinVote = DateTime.Now;
                        eventCurrent.DateMaxVote = DateTime.Now.AddDays(request.DaysAllow);
                        //Valida cantidad mínima de candidatos para comenzar el evento
                        _ = int.TryParse(_configuration.GetSection("MinCandidateToEvent").Value, out var numberMinCandidate);
                        if (eventCurrent.NumberMaxCandidate < numberMinCandidate)
                            throw new CustomException(Models.Enums.MessageCodesApi.MinCandidateRequired, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest, $"El número mínimo de candidatos debe ser: {numberMinCandidate} para comenzar el evento");
                    }
                    else
                    {
                        eventCurrent.IsFinished = true;
                        eventCurrent.DateMaxVote = DateTime.Now;
                        var candidates = eventCurrent.ListVote
                            .GroupBy(v => v.IdCandidate)
                            .Select(cw => new { IdCandidate = cw.Key, TotalVotes = cw.Count() })
                            .OrderByDescending(cw => cw.TotalVotes)
                            .ToList();
                        if (candidates?[0]?.TotalVotes == candidates?[1]?.TotalVotes)
                            throw new CustomException(Models.Enums.MessageCodesApi.EventHasTie, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
                    }
                    var isUpdate = await _electionUnitOfWork.GetEventRepository().Update(eventCurrent);
                    if (!isUpdate)
                        throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    await _electionUnitOfWork.CommitAsync().ConfigureAwait(false);
                    if (eventCurrent.IsFinished)
                        await SendEmailResultsEvent(eventCurrent).ConfigureAwait(false);
                    return _mapper.Map<EventStartStopResponse>(eventCurrent);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error en {@Class}({@Method}): {@Message}", nameof(EventStartStopHandler), nameof(Handle), ex.Message);
                    await _electionUnitOfWork.RollBackAsync().ConfigureAwait(false);
                    throw;
                }
            }

        }

        private async Task SendEmailResultsEvent(Models.Persitence.Event eventCurrent)
        {
            //Obtenemos los mail de todos los usuarios relacionados al evento
            var emailAdministrators = (await _electionUnitOfWork.GetEventAdministratorRepository().GetAsyncInclude(a => a.IdEvent == eventCurrent.Id, includeProperties: i => $"{nameof(i.User)}")).Select(a => a.User.Email);
            var emailParticipants = (await _electionUnitOfWork.GetVoteRepository().GetAsyncInclude(p => p.IdEvent == eventCurrent.Id, includeProperties: i => $"{nameof(i.User)}")).Select(a => a.User.Email);
            var emailCandidates = (await _electionUnitOfWork.GetCandidateRepository().GetAsyncInclude(p => p.IdEvent == eventCurrent.Id, includeProperties: i => $"{nameof(i.User)}")).Select(a => a.User.Email);
            //Creamos la lista completa de email
            var listUserWithRelationship = new List<string>();
            listUserWithRelationship.AddRange(emailAdministrators);
            listUserWithRelationship.AddRange(emailParticipants);
            listUserWithRelationship.AddRange(emailCandidates);
            //Obtenemos solo los valores distintos
            var listEmailsUniques = listUserWithRelationship.Distinct().ToList();
            //Obtenemos la candidata Ganadora
            var candidates = eventCurrent.ListVote.GroupBy(v => v.IdCandidate)
                .Select(cw => new { IdCandidate = cw.Key, TotalVotes = cw.Count() })
                .OrderByDescending(cw => cw.TotalVotes);
            var candidateWinner = candidates.FirstOrDefault();
            var candidateWinnerComplete = (await _electionUnitOfWork.GetCandidateRepository()
                .GetAsyncInclude(c => c.Id == candidateWinner.IdCandidate,
                     includeProperties: i => $"{nameof(i.ListCandidateImage)}"))
                .FirstOrDefault();
            //Configuramos el Template
            var templates = _configuration.GetSection("SendgridConfiguration:Templates").Get<Template[]>();
            var templateNewCandidate = templates.FirstOrDefault(t => t.TemplateName == Models.Static.Template.EventResult);
            var isSend = _notification.SendMail(
               new MailModel()
               {
                   Subject = templateNewCandidate.TemplateName,
                   To = listEmailsUniques,
                   Template = templateNewCandidate.TemplateKey,
                   Params = new
                   {
                       CandidateName = $"{candidateWinnerComplete.User.FirstName} {candidateWinnerComplete.User.FirstLastName}",
                       PathImage = $"https://{candidateWinnerComplete.ListCandidateImage.FirstOrDefault().ImageFullPath}",
                       candidateWinner.TotalVotes,
                       EventName = eventCurrent.Name
                   }
               }
           );
            if (!isSend)
                _logger.LogWarning($"No se pudo Envíar correo de Resultado Eventos");
        }
        #endregion
    }
}
