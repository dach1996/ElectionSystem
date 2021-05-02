using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Response.Candidate;
using Dach.ElectionSystem.Repository.Interfaces;
using MediatR;
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
        private readonly IEventRepository eventRepository;
        public CandidateDeleteHandler(
            ICandidateRepository candidateRepository,
            IMapper mapper,
            IEventRepository eventRepository
            )
        {
            this.candidateRepository = candidateRepository;
            this.mapper = mapper;
            this.eventRepository = eventRepository;
        }
        #endregion

        #region Handler
        public async Task<CandidateDeleteResponse> Handle(CandidateDeleteRequest request, CancellationToken cancellationToken)
        {
           
            var compareEvent = (await eventRepository.GetAsync(e => e.Id == request.IdEvent)).FirstOrDefault();
            if (compareEvent == null)
                throw new CustomException(Models.Enums.MessageCodesApi.NotFindRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.NotFound);
            var candidate = (await candidateRepository.GetAsync(u => u.Id == request.IdCandidate)).FirstOrDefault();
            if (candidate == null)
                throw new CustomException(Models.Enums.MessageCodesApi.NotFindRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.NotFound);
            candidate.IsActive = false;
            var isUpdate = await candidateRepository.Update(candidate);
            if (!isUpdate)
                throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            var response = mapper.Map<CandidateDeleteResponse>(candidate);
            return response;
        }
        #endregion

    }
}
