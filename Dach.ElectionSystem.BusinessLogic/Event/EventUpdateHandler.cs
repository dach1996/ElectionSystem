using System.Linq;

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Models.Response.Event;
using Dach.ElectionSystem.Repository.Interfaces;
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

        public EventUpdateHandler(
            IEventRepository eventRepository,
            IMapper mapper,
            IUserRepository userRepository,
            ILogger<EventUpdateHandler> logger)
        {
            this._eventRepository = eventRepository;
            this._mapper = mapper;
            this.userRepository = userRepository;
            this.logger = logger;
        }
        #endregion
        #region Handler

        public async Task<EventUpdateResponse> Handle(EventUpdateRequest request, CancellationToken cancellationToken)
        {
            //Valida que el evento exista
            var evetGet = (await _eventRepository.GetEventsWithAdministratorAsync(e=>e.Id == request.Id)).FirstOrDefault();
            if (evetGet == null)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.NotFound);
            //Valida que el Usuario que envía el request, esté inscrito al evento
            var userGet = await userRepository.GetUserByUsernameByEmail(request.TokenModel.Email);
              //Actualiza el evento
            evetGet.Category = request.Category;
            evetGet.Description = request.Description;
            evetGet.Image = request.Description;
            evetGet.IsActive = request.IsActive;
            evetGet.MaxPeople = request.MaxPeople;
            evetGet.Name = request.Name;
            evetGet.NumberMaxCandidate = request.NumberMaxCandidate;
            evetGet.NumberMaxPeople = request.NumberMaxPeople;
            //Actualiza en la base de datos
            var isUpdate = await _eventRepository.Update(evetGet);
            if(!isUpdate)
             throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            return _mapper.Map<EventUpdateResponse>(evetGet);
        }
        #endregion


    }
}