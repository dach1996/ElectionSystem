using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Models.Response.Event;
using Dach.ElectionSystem.Repository.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dach.ElectionSystem.BusinessLogic.Event
{
    public class EventGetHandler : IRequestHandler<EventGetRequest, EventGetResponse>
    {
        #region Constructor
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventGetHandler(
            IEventRepository eventRepository,
            IMapper mapper)
        {
            this._eventRepository = eventRepository;
            this._mapper = mapper;
        }
        #endregion
        #region Handler
        public async Task<EventGetResponse> Handle(EventGetRequest request, CancellationToken cancellationToken)
        {
            List<Models.Persitence.Event> listEvents;
            if (request.Id != null)
                listEvents = (await _eventRepository.GetAsync(e => e.Id == request.Id)).ToList();
            else
                listEvents = (await _eventRepository.GetAsync()).ToList();
            var response =  listEvents.OrderByDescending(e => e.Id)
            .Skip(request.Offset)
            .Take(request.Limit)
            .ToList();
            return new EventGetResponse()
            {
                ListEvents = _mapper.Map<List<EventResponseBase>>(response)
            };
        }
        #endregion

    }
}