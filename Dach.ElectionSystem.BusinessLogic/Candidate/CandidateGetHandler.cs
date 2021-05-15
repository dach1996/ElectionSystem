using AutoMapper;
using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Response.Candidate;
using Dach.ElectionSystem.Repository.Interfaces;
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
        private readonly ICandidateRepository candidateRepository;
        private readonly IMapper mapper;

        public CandidateGetHandler(
            ICandidateRepository candidateRepository,
            IMapper mapper)
        {
            this.candidateRepository = candidateRepository;
            this.mapper = mapper;
        }
        #endregion

        #region Handler
        public async Task<CandidateGetResponse> Handle(CandidateGetRequest request, CancellationToken cancellationToken)
        {
            List<Models.Persitence.Candidate> listCandidates;
            listCandidates = (await candidateRepository.GetAsyncInclude(includeProperties: i => $"{nameof(i.ListCandidateImage)}")).ToList();
            var response = mapper.Map<List<CandidateResponseBase>>(listCandidates);
            return new CandidateGetResponse(response);
        }
        #endregion

    }
}
