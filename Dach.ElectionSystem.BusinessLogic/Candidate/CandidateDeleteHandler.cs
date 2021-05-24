using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Response.Candidate;
using Dach.ElectionSystem.Repository.UnitOfWork;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.Candidate
{
    public class CandidateDeleteHandler : IRequestHandler<CandidateDeleteRequest, CandidateDeleteResponse>
    {
        #region Constructor
        private readonly ILogger<CandidateDeleteHandler> _logger;
        private readonly IElectionUnitOfWork _electionUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity _validateIntegrity;
        public CandidateDeleteHandler(
            IMapper mapper,
            ILogger<CandidateDeleteHandler> logger,
            IElectionUnitOfWork electionUnitOfWork,
            ValidateIntegrity validateIntegrity)
        {
            _mapper = mapper;
            _logger = logger;
            _electionUnitOfWork = electionUnitOfWork;
            _validateIntegrity = validateIntegrity;
        }
        #endregion

        #region Handler
        public async Task<CandidateDeleteResponse> Handle(CandidateDeleteRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                try
                {
                    await _electionUnitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                    //Valida que exista la candidata
                    var candidateCurrent = await _validateIntegrity.ValidateCandiate(request.IdCandidate);
                    //valida que el evento sea correcto
                    var isCorrectEvent = candidateCurrent.IdEvent == request.IdEvent;
                    if (!isCorrectEvent)
                        throw new CustomException(Models.Enums.MessageCodesApi.CandidateDontExistInEvent, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.NotFound);
                    //Valida que el candidato no esté desactivado
                    if (!candidateCurrent.IsActive)
                        throw new CustomException(Models.Enums.MessageCodesApi.CandidateIsDesactive, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadGateway);
                    //Valida que la persona que la persona que envía el request sea administrador del evento
                    await _validateIntegrity.IsAdministratorEvent(request.UserContext.Id,request.IdEvent);
                    //Desactva el candidato
                    candidateCurrent.IsActive = false;
                    //Actualiza la información
                    var isUpdate = await _electionUnitOfWork.GetCandidateRepository().Update(candidateCurrent);
                    if (!isUpdate)
                        throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    await _electionUnitOfWork.CommitAsync().ConfigureAwait(false);
                    var response = _mapper.Map<CandidateDeleteResponse>(candidateCurrent);
                    return response;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error en {@Class}({@Method}): {@Message}", nameof(CandidateDeleteHandler), nameof(Handle), ex.Message);
                    await _electionUnitOfWork.RollBackAsync().ConfigureAwait(false);
                    throw;
                }
            }
        }
        #endregion
    }
}
