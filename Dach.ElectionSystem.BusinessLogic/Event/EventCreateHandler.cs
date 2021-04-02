using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Models.Response.Event;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.Event
{
    public class EventCreateHandler : IRequestHandler<EventCreateRequest, EventCreateResponse>
    {
        #region Constructor 
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository userRepository;
        private readonly ValidateIntegrity validateIntegrity;

        public EventCreateHandler(
        IEventRepository eventRepository,
        IMapper mapper,
        IUserRepository userRepository,
        ValidateIntegrity validateIntegrity
        )
        {
            this._eventRepository = eventRepository;
            this._mapper = mapper;
            this.userRepository = userRepository;
            this.validateIntegrity = validateIntegrity;
        }
        #endregion
        #region Handler
        public async Task<EventCreateResponse> Handle(EventCreateRequest request, CancellationToken cancellationToken)
        {
            var userCurrent = await validateIntegrity.ValidateUser(request);
            //Valida que el nombre del evento no exista
            var existEvent = await _eventRepository.GetEventsWithAdministratorAsync(e => e.Name == request.Name);
            if (existEvent.Count() > 0)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.EventRegistered, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
            if (userCurrent.AdministratorEvent.Count() >= userCurrent.MaxEventsAllow)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.MaxEventAllow, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
            var newEvent = _mapper.Map<Models.Persitence.Event>(request);
            //Registramos al usuario como Administrador
            newEvent.AdministratorEvent = new List<AdministratorEvent>()
            {
                new AdministratorEvent(){
                Event= newEvent,
                User = userCurrent
                }
            };
            var hasCreate = await _eventRepository.CreateAsync(newEvent);
            //Valida que el evento sea creado
            if (!hasCreate)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotCreateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            var responseEvent = _mapper.Map<EventCreateResponse>(newEvent);
            return responseEvent;
        }
        #endregion
    }
}
