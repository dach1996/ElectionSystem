using System;
using Microsoft.VisualBasic.CompilerServices;
using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Models.Response.Event;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dach.ElectionSystem.Services.EventService;

namespace Dach.ElectionSystem.BusinessLogic.Event
{
    public class EventCreateHandler : IRequestHandler<EventCreateRequest, EventCreateResponse>
    {
        #region Constructor 
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity validateIntegrity;
        private readonly IConfiguration configuration;
        private readonly IEventService eventService;

        public EventCreateHandler(
        IEventRepository eventRepository,
        IMapper mapper,
        ValidateIntegrity validateIntegrity,
        IConfiguration configuration,
        IEventService eventService
        )
        {
            this._eventRepository = eventRepository;
            this._mapper = mapper;
            this.validateIntegrity = validateIntegrity;
            this.configuration = configuration;
            this.eventService = eventService;
        }
        #endregion
        #region Handler
        public async Task<EventCreateResponse> Handle(EventCreateRequest request, CancellationToken cancellationToken)
        {
            //Valida el usuario que envía request
            var userCurrent = await validateIntegrity.ValidateUser(request);
            //Valida el número de eventos permitidos para el usuario
            var events = await _eventRepository.GetAsync(e => e.IdUser == userCurrent.Id && !e.IsDelete);
            if (events.Count() >= userCurrent.EventNumber.NumberMaxEvent)
                throw new CustomException(Models.Enums.MessageCodesApi.MaxEventAllow, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
            //Valida coerencia de Datos del request
            if (request.MaxPeople && request.NumberMaxCandidate <= 5)
                throw new CustomException(Models.Enums.MessageCodesApi.MaxPeopleEvent, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
            //Valida que el nombre del evento no se encuentre registrado
            if (events.Any(e => e.Name == request.Name))
                throw new CustomException(Models.Enums.MessageCodesApi.EventRegistered, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
            //Validamos las fechas
            request.DateRegister = DateTime.Now;
            await eventService.ValidateDateRegisterEvents(request);
            //Mapeamos el evento
            var newEvent = _mapper.Map<Models.Persitence.Event>(request);
            //Registramos al usuario como creador del evento
            newEvent.UserCreator = userCurrent;
            //Registramos al usuario como Administrador
            newEvent.ListEventAdministrator = new List<Models.Persitence.EventAdministrator>()
            {
                new Models.Persitence.EventAdministrator(){
                Event= newEvent,
                User = userCurrent
                }
            };
            //Agregamos el código único del evento
            newEvent.CodeEvent = Common.Util.GenerateCode(Convert.ToInt32(configuration.GetSection("CharactersCodeEvent").Value));
            //Creamos el evento
            var hasCreate = await _eventRepository.CreateAsync(newEvent);
            //Valida que el evento sea creado
            if (!hasCreate)
                throw new CustomException(Models.Enums.MessageCodesApi.NotCreateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            var responseEvent = _mapper.Map<EventCreateResponse>(newEvent);
            return responseEvent;
        }
        #endregion
    }
}
