using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Response.Candidate;
using Dach.ElectionSystem.Repository.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.Candidate
{
    public class CandidateCreateHandler : IRequestHandler<CandidateCreateRequest, CandidateCreateResponse>
    {
        private readonly ICandidateRepository candidateRepository;
        private readonly IMapper mapper;

        public CandidateCreateHandler(ICandidateRepository candidateRepository, IMapper mapper)
        {
            this.candidateRepository = candidateRepository;
            this.mapper = mapper;
        }
        public async Task<CandidateCreateResponse> Handle(CandidateCreateRequest request, CancellationToken cancellationToken)
        {
            var newCandidate = mapper.Map<Models.Persitence.Candidate>(request);
            var isCreate = await candidateRepository.CreateAsync(newCandidate);
            if (!isCreate)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotCreateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            var response = mapper.Map<CandidateCreateResponse>(newCandidate);
            return response;
        }
    }
}
