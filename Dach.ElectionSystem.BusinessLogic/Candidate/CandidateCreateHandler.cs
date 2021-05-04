using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Response.Candidate;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Services.Data;
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
        private readonly ValidateIntegrity validateIntegrity;

        public CandidateCreateHandler(
            ICandidateRepository candidateRepository,
            IMapper mapper,
            ValidateIntegrity validateIntegrity
            )
        {
            this.candidateRepository = candidateRepository;
            this.mapper = mapper;
            this.validateIntegrity = validateIntegrity;
        }
        #endregion

        #region Handler
        public async Task<CandidateCreateResponse> Handle(CandidateCreateRequest request, CancellationToken cancellationToken)
        {

            //Valida que el evento exista
            var eventCurrent = await validateIntegrity.ValidateEvent(request.IdEvent);
            //Valida que el usuario exista
            var userCurrent = await validateIntegrity.ValidateUser(request.IdUser);
            var isUserCurrentAdministrator = request.UserContext.ListEventAdministrator.Any(e => e.Id == eventCurrent.Id);
             if (!isUserCurrentAdministrator)
                throw new CustomException(Models.Enums.MessageCodesApi.UserIsnotAdministratorEvent, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
            //Valida que el usuario no esté registrado ya como candidato del evento
            var hasRegisterCandidate = eventCurrent.ListCandidate.Any(c => c.IdUser == userCurrent.Id);
            if (hasRegisterCandidate)
                throw new CustomException(Models.Enums.MessageCodesApi.IsCandidateInEvent, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.NotFound);
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
