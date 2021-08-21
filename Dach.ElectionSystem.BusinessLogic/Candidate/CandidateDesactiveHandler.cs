using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Response.Candidate;
using Dach.ElectionSystem.Repository.UnitOfWork;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.Candidate
{
    public class CandidateDesactiveHandler : IRequestHandler<CandidateDesactiveRequest, CandidateDesactiveResponse>
    {
        #region Constructor
        private readonly IElectionUnitOfWork _electionUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity _validateIntegrity;
        public CandidateDesactiveHandler(
            IMapper mapper,
            IElectionUnitOfWork electionUnitOfWork,
            ValidateIntegrity validateIntegrity)
        {
            _mapper = mapper;
            _electionUnitOfWork = electionUnitOfWork;
            _validateIntegrity = validateIntegrity;
        }
        #endregion

        #region Handler
        public async Task<CandidateDesactiveResponse> Handle(CandidateDesactiveRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                try
                {
                    await _electionUnitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                    //Valida que el evento no esté inactivo
                    var eventCurrent  = await _validateIntegrity.ValidateEvent(request.IdEvent);
                    //Valida que exista la candidata
                    var candidateCurrent = await _validateIntegrity.ValidateCandiate(request.IdCandidate,false);
                    //valida que el evento sea correcto
                    var isCorrectEvent = candidateCurrent.IdEvent == request.IdEvent;
                    if (!isCorrectEvent)
                        throw new CustomException(Models.Enums.MessageCodesApi.CandidateDontExistInEvent, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.NotFound);
                    //Valida que la persona que la persona que envía el request sea administrador del evento
                    await _validateIntegrity.IsAdministratorEvent(request.UserContext.Id, request.IdEvent);
                    //Validar que el evento no haya empezado ni terminado
                    await _validateIntegrity.ValidateEventStateNotStarterNotFinished(candidateCurrent.IdEvent).ConfigureAwait(false);
                    //Desactva el candidato
                    candidateCurrent.IsActive = !candidateCurrent.IsActive;
                    //Validar cantidad de Candidatas activas permitidas en el evento
                    if (candidateCurrent.IsActive && eventCurrent.NumberMaxCandidate <= eventCurrent.ListCandidate.Count(c => c.IsActive))
                        throw new CustomException(Models.Enums.MessageCodesApi.MaxCandidateRegister, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
                    //Actualiza la información
                    var isUpdate = await _electionUnitOfWork.GetCandidateRepository().Update(candidateCurrent);
                    if (!isUpdate)
                        throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    await _electionUnitOfWork.CommitAsync().ConfigureAwait(false);
                    var response = _mapper.Map<CandidateDesactiveResponse>(candidateCurrent);
                    return response;
                }
                catch (Exception)
                {
                    await _electionUnitOfWork.RollBackAsync().ConfigureAwait(false);
                    throw;
                }
            }
        }
        #endregion
    }
}
