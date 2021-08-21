using System;
using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Models.Response.Event;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dach.ElectionSystem.Services.EventService;
using Microsoft.Extensions.Logging;
using Dach.ElectionSystem.Repository.UnitOfWork;

namespace Dach.ElectionSystem.BusinessLogic.Event
{
    public class EventCreateHandler : IRequestHandler<EventCreateRequest, EventCreateResponse>
    {
        #region Constructor 
        private readonly ILogger<EventCreateHandler> _logger;
        private readonly IElectionUnitOfWork _electionUnitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IEventService _eventService;

        public EventCreateHandler(
        IMapper mapper,
        IConfiguration configuration,
        IEventService eventService,
        IElectionUnitOfWork electionUnitOfWork,
        ILogger<EventCreateHandler> logger)
        {
            _mapper = mapper;
            _configuration = configuration;
            _eventService = eventService;
            _electionUnitOfWork = electionUnitOfWork;
            _logger = logger;
        }
        #endregion
        #region Handler
        public async Task<EventCreateResponse> Handle(EventCreateRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                try
                {
                    await _electionUnitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                    //Valida el usuario que envía request
                    var userCurrent = request.UserContext;
                    //Valida el número de eventos permitidos para el usuario
                    var events = await _electionUnitOfWork.GetEventRepository().GetAsync(e => e.IdUser == userCurrent.Id && !e.IsDelete);
                    if (events.Count() >= userCurrent.EventNumber.NumberMaxEvent)
                        throw new CustomException(Models.Enums.MessageCodesApi.MaxEventAllow, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
                    //Valida coerencia de Datos del request
                    if (request.MaxPeople && request.NumberMaxCandidate <= 5)
                        throw new CustomException(Models.Enums.MessageCodesApi.MaxPeopleEvent, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
                    //Valida que el nombre del evento no se encuentre registrado
                    if (events.Any(e => e.Name == request.Name))
                        throw new CustomException(Models.Enums.MessageCodesApi.EventRegistered, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
                    //Valida cantidad mínima de candidatos en el evento
                    _ = int.TryParse(_configuration.GetSection("MinCandidateToEvent").Value, out var numberMinCandidate);
                    if (request.NumberMaxCandidate < numberMinCandidate)
                        throw new CustomException(Models.Enums.MessageCodesApi.MinCandidateRequired, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest, $"El número mínimo de candidatos debe ser: {numberMinCandidate}");
                    //Validamos las fechas
                    request.DateRegister = DateTime.Now;
                    request.DateMaxVote = DateTime.Now;
                    request.DateMinVote = DateTime.Now;
                    await _eventService.ValidateDateRegisterEvents(request);
                    //Mapeamos el evento
                    var newEvent = _mapper.Map<Models.Persitence.Event>(request);
                    //Registramos al usuario como creador del evento
                    newEvent.UserCreator = userCurrent;
                    newEvent.Image = null;
                    //Registramos al usuario como Administrador
                    newEvent.ListEventAdministrator = new List<Models.Persitence.EventAdministrator>()
                        {
                            new Models.Persitence.EventAdministrator(){
                            Event= newEvent,
                            User = userCurrent
                            }
                        };
                    //Agregamos el código único del evento
                    newEvent.CodeEvent = Common.Util.GenerateCode(Convert.ToInt32(_configuration.GetSection("CharactersCodeEvent").Value));
                    //Creamos el evento
                    var hasCreate = await _electionUnitOfWork.GetEventRepository().CreateAsync(newEvent);
                    //Valida que el evento sea creado
                    if (!hasCreate)
                        throw new CustomException(Models.Enums.MessageCodesApi.NotCreateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    await _electionUnitOfWork.CommitAsync().ConfigureAwait(false);
                    var responseEvent = _mapper.Map<EventCreateResponse>(newEvent);
                    return responseEvent;

                }
                catch (Exception)
                {
                    await _electionUnitOfWork.RollBackAsync().ConfigureAwait(false);
                    throw;
                }
            }
        }
        #endregion
    }
}
