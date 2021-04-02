using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Models.Response.Event;
using Dach.ElectionSystem.Repository.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.Event
{
    public class EventDeleteHandler : IRequestHandler<EventDeleteRequest, EventDeleteResponse>
    {
        #region Constructor
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository userRepository;

        public EventDeleteHandler(
            IEventRepository eventRepository,
            IMapper mapper,
            IUserRepository userRepository)
        {
            this._eventRepository = eventRepository;
            this._mapper = mapper;
            this.userRepository = userRepository;
        }
        #endregion
        #region Handler
        public async Task<EventDeleteResponse> Handle(EventDeleteRequest request, CancellationToken cancellationToken)
        {

           
             
            //Obtiene evento por ID
            var getEvent = await _eventRepository.GetByIdAsync(request.Id);
            if (getEvent == null)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotFindRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.NotFound);
            //Valida que evento esté Activo
            if (!getEvent.IsActive)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.EventIsInactive, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest);
            //Obtiene el  usuario y valida que tenga ese evento registrado
            var user = await userRepository.GetUserByUsernameByEmail(request.TokenModel.Email);
              getEvent.IsActive = false;
            var responseDelete = await _eventRepository.Update(getEvent);
            //Valida que el evento se haya desactivado
            if (!responseDelete)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            return _mapper.Map<EventDeleteResponse>(getEvent);
        }
        #endregion

    }
}
