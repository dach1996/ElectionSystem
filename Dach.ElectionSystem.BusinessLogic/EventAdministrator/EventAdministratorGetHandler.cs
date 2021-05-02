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
        private readonly ValidateIntegrity validateIntegrity;

        public EventAdministratorGetHandler(
            IMapper mapper,
             ValidateIntegrity validateIntegrity)
        {
            this._mapper = mapper;
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
                throw new CustomException(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict,
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