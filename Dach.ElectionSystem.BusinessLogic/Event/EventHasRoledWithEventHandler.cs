using AutoMapper;
using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Models.Response.Event;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Dach.ElectionSystem.Repository.UnitOfWork;
using Dach.ElectionSystem.Services.Data;

namespace Dach.ElectionSystem.BusinessLogic.Event
{
    public class EventHasRoledWithEventHandler : IRequestHandler<EventHasRoledWithEventRequest, EventHasRoledWithEventResponse>
    {
        #region Constructor 
        private readonly IElectionUnitOfWork _electionUnitOfWork;
        private readonly ValidateIntegrity _validateIntegrity;

        public EventHasRoledWithEventHandler(
        IElectionUnitOfWork electionUnitOfWork,
        ValidateIntegrity validateIntegrity)
        {
            _electionUnitOfWork = electionUnitOfWork;
            _validateIntegrity = validateIntegrity;
        }
        #endregion
        #region Handler
        public async Task<EventHasRoledWithEventResponse> Handle(EventHasRoledWithEventRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                //Validamos que exista el usuario
                _ = await _validateIntegrity.ValidateUser(request.IdUserComapare);
                //Validamos que exista el evento
                _ = await _validateIntegrity.ValidateEvent(request.IdEvent);
                //Validamos que el usuario tenga algún registro en el evento
                _ = await _validateIntegrity.HasRegisterWithEvent(request.IdUserComapare, request.IdEvent);
                //Encontramos los datos necesarios
                return new EventHasRoledWithEventResponse()
                {
                    HasRelationshipEvent = true
                };
            }
        }
        #endregion
    }
}
