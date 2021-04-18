using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Response.Candidate;
using Dach.ElectionSystem.Repository.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CandidateGetHandler> logger;
        private readonly IEventRepository eventRepository;

        public CandidateGetHandler(
            ICandidateRepository candidateRepository,
            IMapper mapper,
            ILogger<CandidateGetHandler> logger,
            IEventRepository eventRepository)
        {
            this.candidateRepository = candidateRepository;
            this.mapper = mapper;
            this.logger = logger;
            this.eventRepository = eventRepository;
        }
        #endregion

        #region Handler
             public async Task<CandidateGetResponse> Handle(CandidateGetRequest request, CancellationToken cancellationToken)
        {
            var listCandidates = new List<Models.Persitence.Candidate>();
                listCandidates = (await  candidateRepository.GetAsync()).ToList();
           
            var response = mapper.Map<List<CandidateResponseBase>>(listCandidates);
            return new CandidateGetResponse(){
                ListCandidate =response
            };
        }
        #endregion
       
    }
}
