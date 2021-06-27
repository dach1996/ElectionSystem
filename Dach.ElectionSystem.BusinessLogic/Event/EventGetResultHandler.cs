using AutoMapper;
using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Models.Response.Event;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Dach.ElectionSystem.Repository.UnitOfWork;
using Dach.ElectionSystem.Services.Data;
using System.Linq;
using System.Collections.Generic;

namespace Dach.ElectionSystem.BusinessLogic.Event
{
    public class EventGetResultHandler : IRequestHandler<EventGetResultRequest, EventGetResultResponse>
    {
        #region Constructor 
        private readonly IElectionUnitOfWork _electionUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity _validateIntegrity;

        public EventGetResultHandler(
        IMapper mapper,
        IElectionUnitOfWork electionUnitOfWork,
        ValidateIntegrity validateIntegrity)
        {
            _mapper = mapper;
            _electionUnitOfWork = electionUnitOfWork;
            _validateIntegrity = validateIntegrity;
        }
        #endregion
        #region Handler
        public async Task<EventGetResultResponse> Handle(EventGetResultRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                //Valida que el evento no esté inactivo
                _ = await _validateIntegrity.ValidateEvent(request.IdEvent);
                //Valida el usuario que envía request
                var userCurrent = request.UserContext;
                //Validamos que el usuario tenga algún registro en el evento
                _ = await _validateIntegrity.HasRegisterWithEvent(userCurrent.Id, request.IdEvent);
                //Encontramos los datos necesarios
                var eventCurrent = (await _electionUnitOfWork.GetEventRepository().GetAsyncInclude(e => e.Id == request.IdEvent,
                    includeProperties: e => $"{nameof(e.ListCandidate)}.{nameof(Models.Persitence.Candidate.User)},{nameof(e.ListCandidate)}.{nameof(Models.Persitence.Candidate.ListCandidateImage)},{nameof(e.ListVote)}")).FirstOrDefault();
                //Creamos la respuesta
                EventGetResultResponse response = new();
                //Asignamos los datos de los candidatos
                response.Candidates = _mapper.Map<List<CandidateWithVote>>(eventCurrent.ListCandidate);
                response.Candidates.ForEach(c =>
                {
                    c.NumberVotes = eventCurrent.ListVote.Count(votes => votes.IdCandidate == c.Id);
                });
                //Asignamos los datos del evento
                response.Event = _mapper.Map<EventBaseResponse>(eventCurrent);
                response.Event.Image = $"{request.PathRoot}/{response.Event.Image}";
                //Asignamos los datos de total de eventos
                response.TotalParticipantsVotes = eventCurrent.ListVote.Count(v => v.HasVote);
                response.TotalParticipantsWithOutVotes = eventCurrent.ListVote.Count(v => !v.HasVote);
                return response;
            }
        }
        #endregion
    }
}
