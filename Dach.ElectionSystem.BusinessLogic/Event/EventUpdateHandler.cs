using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Models.Response.Event;
using Dach.ElectionSystem.Repository.UnitOfWork;
using Dach.ElectionSystem.Services.Data;
using Dach.ElectionSystem.Services.EventService;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dach.ElectionSystem.BusinessLogic.Event
{
    public class EventUpdateHandler : IRequestHandler<EventUpdateRequest, EventUpdateResponse>
    {
        #region Constructor
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity _validateIntegrity;
        private readonly IEventService _eventService;
        private readonly ILogger<EventUpdateHandler> _logger;
        private readonly IElectionUnitOfWork _electionUnitOfWork;

        public EventUpdateHandler(
            IMapper mapper,
            ValidateIntegrity validateIntegrity,
            IEventService eventService,
            ILogger<EventUpdateHandler> logger,
            IElectionUnitOfWork electionUnitOfWork)
        {
            _mapper = mapper;
            _validateIntegrity = validateIntegrity;
            _eventService = eventService;
            _logger = logger;
            _electionUnitOfWork = electionUnitOfWork;
        }
        #endregion
        #region Handler

        public async Task<EventUpdateResponse> Handle(EventUpdateRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                try
                {
                    await _electionUnitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                    //Valida que el evento exista
                    var eventCurrent = await _validateIntegrity.ValidateEvent(request.Id.Value);
                    //Valida que el Usuario que envía el request, sea administrtador del evento
                    var isUserAdministrator = eventCurrent.ListEventAdministrator.Count(e => e.IdUser == request.UserContext.Id);
                    if (isUserAdministrator == 0)
                        throw new CustomException(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.NotFound,
                                                    $"El usuario con Id: {request.UserContext.Id} no es administrador en el evento: {eventCurrent.Name}");
                    //Valida que el usuario administrador no tenga un evento con el mismo nombre:
                    var administratorEvent = await _electionUnitOfWork.GetUserRepository().GetByIdAsync(eventCurrent.IdUser);
                    if (administratorEvent == null)
                        throw new CustomException(Models.Enums.MessageCodesApi.ErrorGeneric, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError,
                                                       $"El creador del evento con ID: {eventCurrent.Id} no es el Usuario con Id:{eventCurrent.IdUser}");
                    //Valida  que no exista evento con el mismo nombre en la cuenta del creador
                    var nameEventExist = (await _electionUnitOfWork.GetEventRepository().GetAsync(e => e.IdUser == administratorEvent.Id
                                                                                && e.Name == request.Name)).FirstOrDefault();
                    if (nameEventExist != null && nameEventExist.Id != eventCurrent.Id)
                        throw new CustomException(Models.Enums.MessageCodesApi.EventRegistered, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    //Valida coerencia de Datos del request
                    if (request.MaxPeople && request.NumberMaxCandidate <= 5)
                        throw new CustomException(Models.Enums.MessageCodesApi.MaxPeopleEvent, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
                    //Validamos las fechas
                    request.DateRegister = eventCurrent.DateRegister;
                    //TODO: Quitar esta invalidación
                    // await eventService.ValidateDateRegisterEvents(request);
                    //Actualiza el evento
                    UpdateDataEvent(request, eventCurrent);
                    //Actualiza en la base de datos
                    var isUpdate = await _electionUnitOfWork.GetEventRepository().Update(eventCurrent);
                    if (!isUpdate)
                        throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    await _electionUnitOfWork.CommitAsync().ConfigureAwait(false);
                    return _mapper.Map<EventUpdateResponse>(eventCurrent);

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error en {@Class}({@Method}): {@Message}", nameof(EventUpdateHandler), nameof(Handle), ex.Message);
                    await _electionUnitOfWork.RollBackAsync().ConfigureAwait(false);
                    throw;
                }
            }
        }

        private static void UpdateDataEvent(EventUpdateRequest request, Models.Persitence.Event eventCurrent)
        {
            eventCurrent.Category = request.Category;
            eventCurrent.Description = request.Description;
            eventCurrent.MaxPeople = request.MaxPeople;
            eventCurrent.Name = request.Name;
            eventCurrent.NumberMaxCandidate = request.NumberMaxCandidate;
            eventCurrent.NumberMaxPeople = request.NumberMaxPeople;
            eventCurrent.DateMaxRegisterCandidate = request.DateMaxRegisterCandidate.Value;
            eventCurrent.DateMaxRegisterParticipants = request.DateMaxRegisterParticipants.Value;
            eventCurrent.DateMaxVote = request.DateMaxVote.Value;
            eventCurrent.DateMinVote = request.DateMinVote.Value;
        }
        #endregion
    }
}