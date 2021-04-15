using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Response.Candidate;
using Dach.ElectionSystem.Repository.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;
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
            var group = (await groupRepository.GetAsync(g => g.Id == request.IdGroup)).FirstOrDefault();
            if (group == null)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotFindRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.NotFound);
           
            var compareEvent = (await eventRepository.GetAsync(e => e.Id == request.IdEvent)).FirstOrDefault();
            if (compareEvent == null)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotFindRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.NotFound);
            var candidate = (await candidateRepository.GetAsync(u => u.Id == request.IdCandidate)).FirstOrDefault();
            if (candidate == null)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotFindRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.NotFound);
            candidate.IsActive=false;
             var isUpdate = await candidateRepository.Update(candidate);
            if (!isUpdate)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            var response = mapper.Map<CandidateDeleteResponse>(candidate);
            return response;
        }
        #endregion
       
    }
}
