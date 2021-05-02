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
    public class CandidateUpdateHandler : IRequestHandler<CandidateUpdateRequest, CandidateUpdateResponse>
    {
        #region Constructor
        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper mapper;
        public CandidateUpdateHandler(
            ICandidateRepository candidateRepository,
            IMapper mapper  )
        {
            this._candidateRepository = candidateRepository;
            this.mapper = mapper;         
        }
        #endregion

        #region Handler
             public async Task<CandidateUpdateResponse> Handle(CandidateUpdateRequest request, CancellationToken cancellationToken)
        {
            var updateCandidate = (await _candidateRepository.GetAsync(c => c.Id==request.IdCandidate)).FirstOrDefault();
            if(updateCandidate==null)
             throw new CustomException(Models.Enums.MessageCodesApi.NotFindRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.NotFound);
            
            updateCandidate.Age = request.Age.Value;
            updateCandidate.Details = request.Details;
            updateCandidate.Image =  request.Image;
            updateCandidate.PostionsWorks = request.PostionsWorks;
            updateCandidate.Role = request.Role;
            updateCandidate.ProposalDetails = request.ProposalDetails;
            var isUpdate = await _candidateRepository.Update(updateCandidate);
            if (!isUpdate)
                throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            var response = mapper.Map<CandidateUpdateResponse>(updateCandidate);
            return response;
        }
        #endregion
       
    }
}
