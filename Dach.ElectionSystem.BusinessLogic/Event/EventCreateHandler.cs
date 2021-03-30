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
    public class EventCreateHandler : IRequestHandler<EventCreateRequest, EventCreateResponse>
    {
        #region Constructor 
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventCreateHandler(IEventRepository eventRepository, IMapper mapper)
        {
            this._eventRepository = eventRepository;
            this._mapper = mapper;
        }
        #endregion
        #region Handler
        public async Task<EventCreateResponse> Handle(EventCreateRequest request, CancellationToken cancellationToken)
        {
            if(request.TokenModel.RolUser==Models.Enums.RolUser.User)
              throw new ExceptionCustom(Models.Enums.MessageCodesApi.InsufficientPrivileges, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
            var existEvent = (await _eventRepository.GetAsync(e=> e.Name == request.Name)).FirstOrDefault();
            if(existEvent!=null)
             throw new ExceptionCustom(Models.Enums.MessageCodesApi.DataExist, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
            var newEvent = _mapper.Map<Models.Persitence.Event>(request);
            //// TODO: Cuantificar numéro de eventos permitidos por usuario
            newEvent.IsActive=true;
            var hasCreate = await _eventRepository.CreateAsync(newEvent);
            if (!hasCreate)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotCreateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            var responseEvent = _mapper.Map<EventCreateResponse>(newEvent);
            return responseEvent;
        }
        #endregion
    }
}
