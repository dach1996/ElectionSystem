using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Response.Candidate;
using Dach.ElectionSystem.Repository.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.Candidate
{
    public class CandidateDeleteHandler : IRequestHandler<CandidateDeleteRequest, CandidateDeleteResponse>
    {
        #region Constructor
        private readonly ICandidateRepository candidateRepository;
        private readonly IMapper mapper;
        private readonly ILogger<CandidateDeleteHandler> logger;
        private readonly IEventRepository eventRepository;
        private readonly IGroupRepository groupRepository;

        public CandidateDeleteHandler(
            ICandidateRepository candidateRepository,
            IMapper mapper,
            ILogger<CandidateDeleteHandler> logger,
            IEventRepository eventRepository,
            IGroupRepository groupRepository)
        {
            this.candidateRepository = candidateRepository;
            this.mapper = mapper;
            this.logger = logger;
            this.eventRepository = eventRepository;
            this.groupRepository = groupRepository;
        }
        #endregion

        #region Handler
             public async Task<CandidateDeleteResponse> Handle(CandidateDeleteRequest request, CancellationToken cancellationToken)
        {
            var newCandidate = mapper.Map<Models.Persitence.Candidate>(request);
            var isCreate = await candidateRepository.CreateAsync(newCandidate);
            if (!isCreate)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotCreateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            var response = mapper.Map<CandidateCreateResponse>(newCandidate);
            return null;
        }
        #endregion
       
    }
}
