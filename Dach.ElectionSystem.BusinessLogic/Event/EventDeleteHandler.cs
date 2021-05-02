using System;
using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Models.Response.Event;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.Event
{
    public class EventDeleteHandler : IRequestHandler<EventDeleteRequest, EventDeleteResponse>
    {
        #region Constructor
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity validateIntegrity;

        public EventDeleteHandler(
            IEventRepository eventRepository,
            IMapper mapper,
            ValidateIntegrity validateIntegrity)
        {
            this._eventRepository = eventRepository;
            this._mapper = mapper;
            this.validateIntegrity = validateIntegrity;
        }
        #endregion
        #region Handler
        public async Task<EventDeleteResponse> Handle(EventDeleteRequest request, CancellationToken cancellationToken)
        {
            //Obtiene evento por ID y verifica si está borrado el evento
            var eventCurrent = await validateIntegrity.ValidateEvent(request.Id);
            //Valida que el usuario administrador no tenga un evento con el mismo nombre:
            var isUserCurrentCreatorEvent = eventCurrent.IdUser == request.UserContext.Id;
            if (!isUserCurrentCreatorEvent)
                throw new CustomException(Models.Enums.MessageCodesApi.EventCreator, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
            eventCurrent.IsDelete = true;
            eventCurrent.Name = $"{eventCurrent.Name}_{DateTime.Now}_Delete";
            var responseDelete = await _eventRepository.Update(eventCurrent);
            //Valida que el evento se haya desactivado
            if (!responseDelete)
                throw new CustomException(Models.Enums.MessageCodesApi.NotDeleteRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            return _mapper.Map<EventDeleteResponse>(eventCurrent);
        }
        #endregion
    }
}
