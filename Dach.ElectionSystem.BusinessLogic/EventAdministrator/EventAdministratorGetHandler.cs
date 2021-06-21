using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.EventAdministrator;
using Dach.ElectionSystem.Models.Response.EventAdministrator;
using Dach.ElectionSystem.Services.Data;
using MediatR;

namespace Dach.ElectionSystem.BusinessLogic.EventAdministrator
{
    public class EventAdministratorGetHandler : IRequestHandler<EventAdministratorGetRequest, EventAdministratorGetResponse>
    {
        #region Constructor
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity _validateIntegrity;

        public EventAdministratorGetHandler(
            IMapper mapper,
            ValidateIntegrity validateIntegrity)
        {
            _mapper = mapper;
            _validateIntegrity = validateIntegrity;
        }
        #endregion
        #region Handler
        public async Task<EventAdministratorGetResponse> Handle(EventAdministratorGetRequest request, CancellationToken cancellationToken)
        {
            //Valida que exista el evento
            var eventCurrent = await _validateIntegrity.ValidateEvent(request.IdEvent);
            //Valida que el usuario de contexto sea administrador en este e vento
           await _validateIntegrity.IsAdministratorEvent(request.UserContext.Id, eventCurrent.Id);
            //Creamos la respuesta
            var response = new EventAdministratorGetResponse()
            {
                ListEventAdministrators = _mapper.Map<List<EventAdministratorBaseResponse>>(eventCurrent.ListEventAdministrator)
            };
            return response;
        }
        #endregion

    }
}