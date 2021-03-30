using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Models.Response.Event;
using Dach.ElectionSystem.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.Event
{
    public class EventDeleteHandler : IRequestHandler<EventDeleteRequest, EventDeleteResponse>
    {
        #region Constructor
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public EventDeleteHandler(IEventRepository eventRepository, IMapper mapper)
        {
            this._eventRepository = eventRepository;
            this._mapper = mapper;
        }
        #endregion
        #region Handler
        public async Task<EventDeleteResponse> Handle(EventDeleteRequest request, CancellationToken cancellationToken)
        {
            var getEvent = await _eventRepository.GetByIdAsync(request.Id);
            if (getEvent == null)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotFindRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.NotFound);
            if (!getEvent.IsActive)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.EventIsInactive, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
            getEvent.IsActive = false;
            var responseDelete = await _eventRepository.Update(getEvent);
            if (!responseDelete)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            return _mapper.Map<EventDeleteResponse>(getEvent);
        }
        #endregion

    }
}
