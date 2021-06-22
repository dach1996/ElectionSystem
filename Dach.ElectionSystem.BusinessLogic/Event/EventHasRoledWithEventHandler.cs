using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Models.Response.Event;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Dach.ElectionSystem.Repository.UnitOfWork;
using Dach.ElectionSystem.Services.Data;
using System.Linq;
using Dach.ElectionSystem.Models.Enums;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using System.Net;

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
                //Validamos que el usuario tenga algún registro en el evento
                var events = await _electionUnitOfWork.GetEventRepository().GetAsyncInclude(u => u.Id == request.IdEvent, includeProperties: e => $"{nameof(e.ListCandidate)},{nameof(e.ListEventAdministrator)},{nameof(e.ListVote)}");
                if (!events.Any())
                    throw new CustomException(MessageCodesApi.ResourceNotFound, ResponseType.Error, HttpStatusCode.NotFound, $"El evento con id :{request.IdEvent} no existe");
                var eventCurrent = events.FirstOrDefault();
                var response = new EventHasRoledWithEventResponse();
                if (eventCurrent.ListEventAdministrator.Any(le => le.IdUser == request.IdUserComapare && le.IsActive))
                    response.AdmnistratorRelation = true;
                if (eventCurrent.ListVote.Any(le => le.IdUser == request.IdUserComapare && le.IsActive))
                    response.ParticipantRelation = true;
                if (eventCurrent.ListCandidate.Any(le => le.IdUser == request.IdUserComapare && le.IsActive))
                    response.CandidateRelation = true;
                if (!response.AdmnistratorRelation && !response.CandidateRelation && !response.ParticipantRelation)
                    throw new CustomException(MessageCodesApi.ResourceNotFound, ResponseType.Error, HttpStatusCode.NotFound, $"El usuario con  ID: {request.IdUserComapare} no posee ningún registro en el evento con ID: {request.IdEvent}");
                response.HasRelationshipEvent = true;
                return response;
            }
        }
        #endregion
    }
}
