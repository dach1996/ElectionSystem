using System.Linq;

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Models.Response.Event;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dach.ElectionSystem.BusinessLogic.Event
{
    public class EventUpdateHandler : IRequestHandler<EventUpdateRequest, EventUpdateResponse>
    {
        #region Constructor
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository userRepository;
        private readonly ILogger<EventUpdateHandler> logger;
        private readonly ValidateIntegrity validateIntegrity;

        public EventUpdateHandler(
            IEventRepository eventRepository,
            IMapper mapper,
            IUserRepository userRepository,
            ILogger<EventUpdateHandler> logger,
            ValidateIntegrity validateIntegrity)
        {
            this._eventRepository = eventRepository;
            this._mapper = mapper;
            this.userRepository = userRepository;
            this.logger = logger;
            this.validateIntegrity = validateIntegrity;
        }
        #endregion
        #region Handler

        public async Task<EventUpdateResponse> Handle(EventUpdateRequest request, CancellationToken cancellationToken)
        {
            //Valida que el evento exista
            var eventCurrent = await validateIntegrity.ValidateEvent(request.Id.Value);
                //Valida que el Usuario que envía el request, sea administrtador del evento
            var isUserAdministrator = eventCurrent.ListEventAdministrator.Where(e => e.IdUser == request.UserContext.Id).Count();
            if (isUserAdministrator == 0)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.NotFound,
                                            $"El usuario con Id: {request.UserContext.Id} no es administrador en el evento: {eventCurrent.Name}");
            //Valida que el usuario administrador no tenga un evento con el mismo nombre:
            var administratorEvent = await userRepository.GetByIdAsync(eventCurrent.IdUser);
            if (administratorEvent == null)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.ErrorGeneric, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError,
                                               $"El creador del evento con ID: {eventCurrent.Id} no es el Usuario con Id:{eventCurrent.IdUser}");
            //Valida  que no exista evento con el mismo nombre en la cuenta del creador
            var nameEventExist = (await _eventRepository.GetAsync(e =>   e.IdUser == administratorEvent.Id 
                                                                        && e.Name == request.Name)).FirstOrDefault();
            if(nameEventExist!=null && nameEventExist.Id!=eventCurrent.Id)
                  throw new ExceptionCustom(Models.Enums.MessageCodesApi.EventRegistered, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError); 
           //Valida coerencia de Datos del request
            if (request.MaxPeople)
            {
                if (request.NumberMaxCandidate <= 5)
                    throw new ExceptionCustom(Models.Enums.MessageCodesApi.MaxPeopleEvent, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
            }
            //Actualiza el evento
            eventCurrent.Category = request.Category;
            eventCurrent.Description = request.Description;
            eventCurrent.Image = request.Description;
            eventCurrent.IsActive = request.IsActive;
            eventCurrent.MaxPeople = request.MaxPeople;
            eventCurrent.Name = request.Name;
            eventCurrent.NumberMaxCandidate = request.NumberMaxCandidate;
            eventCurrent.NumberMaxPeople = request.NumberMaxPeople;
            //Actualiza en la base de datos
            var isUpdate = await _eventRepository.Update(eventCurrent);
            if (!isUpdate)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            return _mapper.Map<EventUpdateResponse>(eventCurrent);
        }
        #endregion


    }
}