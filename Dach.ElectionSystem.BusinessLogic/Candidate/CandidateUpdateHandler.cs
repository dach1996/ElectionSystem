using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Response.Candidate;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
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
        private readonly ValidateIntegrity validateIntegrity;

        public CandidateUpdateHandler(
            ICandidateRepository candidateRepository,
            IMapper mapper,
            ValidateIntegrity validateIntegrity)
        {
            this._candidateRepository = candidateRepository;
            this.mapper = mapper;
            this.validateIntegrity = validateIntegrity;
        }
        #endregion

        #region Handler
        public async Task<CandidateUpdateResponse> Handle(CandidateUpdateRequest request, CancellationToken cancellationToken)
        {
             //Valida que el evento exista
            var eventCurrent = await validateIntegrity.ValidateEvent(request.IdEvent);
            // Valida que la candidata Exista
            var updateCandidate = await validateIntegrity.ValidateCandiate(request.IdCandidate);
            //Validar la fecha máxima para crear candidatos
            var isDateValid = eventCurrent.DateMaxRegisterCandidate >= DateTime.Now;
            if (!isDateValid)
                throw new CustomException(Models.Enums.MessageCodesApi.IncorrectDates, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadGateway,
                                            $"La fecha máxima para poder registrar candidatos ha terminado.");
            updateCandidate.Age = request.Age.Value;
            updateCandidate.Details = request.Details;
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
