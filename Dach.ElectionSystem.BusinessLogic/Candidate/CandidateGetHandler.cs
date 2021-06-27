using AutoMapper;
using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Response.Candidate;
using Dach.ElectionSystem.Repository.UnitOfWork;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.Candidate
{
    public class CandidateGetHandler : IRequestHandler<CandidateGetRequest, CandidateGetResponse>
    {
        #region Constructor
        private readonly IElectionUnitOfWork _electionUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity _validateIntegrity;

        public CandidateGetHandler(
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
        public async Task<CandidateGetResponse> Handle(CandidateGetRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                //Valida que el evento no esté inactivo
                _ = await _validateIntegrity.ValidateEvent(request.IdEvent);
                //Valida que tenga relación con el evento
                _ = await _validateIntegrity.HasRegisterWithEvent(request.UserContext.Id, request.IdEvent);
                List<Models.Persitence.Candidate> listCandidates;
                if (request.IdUser != null)
                    listCandidates = (await _electionUnitOfWork.GetCandidateRepository().GetAsyncInclude(c => c.IdUser == request.IdUser && c.IdEvent == request.IdEvent,
                    includeProperties: i => $"{nameof(i.ListCandidateImage)},{nameof(i.User)}")).ToList();
                else
                    listCandidates = (await _electionUnitOfWork.GetCandidateRepository().GetAsyncInclude(c => c.IdEvent == request.IdEvent,
                    includeProperties: i => $"{nameof(i.ListCandidateImage)},{nameof(i.User)}")).ToList();
                var totalCandidate = listCandidates.Count;
                listCandidates = listCandidates.OrderByDescending(e => e.Id)
                .Skip(request.Offset)
                .Take(request.Limit)
                .ToList();
                if (request.OnlyActives.HasValue)
                    listCandidates = listCandidates.Where(e => e.IsActive).ToList();
                var response = _mapper.Map<List<CandidateBaseResponse>>(listCandidates);
                return new CandidateGetResponse(response, totalCandidate);
            }
        }
        #endregion
    }
}
