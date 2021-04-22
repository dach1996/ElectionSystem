using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.EventAdministrator;
using Dach.ElectionSystem.Models.Response.EventAdministrator;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dach.ElectionSystem.BusinessLogic.EventAdministrator
{
    public class EventAdministratorGetHandler : IRequestHandler<EventAdministratorGetRequest, EventAdministratorGetResponse>
    {
        #region Constructor
        private readonly IEventAdministratorRepository _eventAdministratorRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository userRepository;
        private readonly ILogger<EventAdministratorGetHandler> logger;
        private readonly ValidateIntegrity validateIntegrity;

        public EventAdministratorGetHandler(
            IEventAdministratorRepository EventAdministratorRepository,
            IMapper mapper,
            IUserRepository userRepository,
            ILogger<EventAdministratorGetHandler> logger,
             ValidateIntegrity validateIntegrity)
        {
            this._eventAdministratorRepository = EventAdministratorRepository;
            this._mapper = mapper;
            this.userRepository = userRepository;
            this.logger = logger;
            this.validateIntegrity = validateIntegrity;
        }
        #endregion
        #region Handler
        public async Task<EventAdministratorGetResponse> Handle(EventAdministratorGetRequest request, CancellationToken cancellationToken)
        {
            //Valida que exista el evento
            var events = await validateIntegrity.ValidateEvent(request.IdEvent);
            //Valida que el usuario de contexto sea administrador en este e vento
            var isUserCurrentAdministrator = request.UserContext.ListEventAdministrator.Exists(e => e.Id == events.Id);
            if (!isUserCurrentAdministrator)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict,
                "El no tiene permisos para consultar administradores a este evento");
            //Creamos la respuesta
            var response = new EventAdministratorGetResponse()
            {
                ListEventAdministrators = _mapper.Map<List<EventAdministratorResponseBase>>(events.ListEventAdministrator)
            };
            return response;
        }
        #endregion

    }
}