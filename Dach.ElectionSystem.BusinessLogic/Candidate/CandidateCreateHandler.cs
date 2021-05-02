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
    public class CandidateCreateHandler : IRequestHandler<CandidateCreateRequest, CandidateCreateResponse>
    {
        #region Constructor
        private readonly ICandidateRepository candidateRepository;
        private readonly IMapper mapper;
        private readonly IEventRepository eventRepository;
        private readonly IUserRepository userRepository;

        public CandidateCreateHandler(
            ICandidateRepository candidateRepository,
            IMapper mapper,
            IEventRepository eventRepository,
            IUserRepository userRepository)
        {
            this.candidateRepository = candidateRepository;
            this.mapper = mapper;
            this.eventRepository = eventRepository;
            this.userRepository = userRepository;
        }
        #endregion

        #region Handler
        public async Task<CandidateCreateResponse> Handle(CandidateCreateRequest request, CancellationToken cancellationToken)
        {
           
            var compareEvent = (await eventRepository.GetAsync(e => e.Id == request.IdEvent)).FirstOrDefault();
            if (compareEvent == null)
                throw new CustomException(Models.Enums.MessageCodesApi.NotFindRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.NotFound);
            var user = (await userRepository.GetAsync(u => u.Id == request.IdUser)).FirstOrDefault();
            if (user == null)
                throw new CustomException(Models.Enums.MessageCodesApi.NotFindRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.NotFound);
            var newCandidate = mapper.Map<Models.Persitence.Candidate>(request);
            var isCreate = await candidateRepository.CreateAsync(newCandidate);

            if (!isCreate)
                throw new CustomException(Models.Enums.MessageCodesApi.NotCreateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            var response = mapper.Map<CandidateCreateResponse>(newCandidate);
            return response;
        }
        #endregion

    }
}
