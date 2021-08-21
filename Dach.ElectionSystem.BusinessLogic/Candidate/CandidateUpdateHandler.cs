using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Response.Candidate;
using Dach.ElectionSystem.Repository.UnitOfWork;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.Candidate
{
    public class CandidateUpdateHandler : IRequestHandler<CandidateUpdateRequest, CandidateUpdateResponse>
    {
        #region Constructor
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity _validateIntegrity;
        private readonly IElectionUnitOfWork _electionUnitOfWork;

        public CandidateUpdateHandler(
            IMapper mapper,
            ValidateIntegrity validateIntegrity,
            IElectionUnitOfWork electionUnitOfWork)
        {
            _mapper = mapper;
            _validateIntegrity = validateIntegrity;
            _electionUnitOfWork = electionUnitOfWork;
        }
        #endregion

        #region Handler
        public async Task<CandidateUpdateResponse> Handle(CandidateUpdateRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                try
                {
                    await _electionUnitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                    //Valida que el evento exista
                    await _validateIntegrity.ValidateEvent(request.IdEvent);
                    // Valida que la candidata Exista
                    var candidateCurrent = await _validateIntegrity.ValidateCandiateWithUserAndEvent(request.UserContext.Id, request.IdEvent);
                    //Valida que la candidata esté activa para actualizar los datos
                    if(!candidateCurrent.IsActive)
                       throw new CustomException(Models.Enums.MessageCodesApi.CandidateIsDesactive, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadGateway);                 
                    //Validar que el evento no haya empezado ni terminado
                    await _validateIntegrity.ValidateEventStateNotStarterNotFinished(candidateCurrent.IdEvent).ConfigureAwait(false);
                    //Validamos que el usuario y el candidato sean el mismo
                    if (request.UserContext.Id != candidateCurrent.IdUser)
                        throw new CustomException(Models.Enums.MessageCodesApi.UserIsNotCandidate, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadGateway);
                    //Actualizamos los datos del modelo
                    var additionalInformation = JsonSerializer.Serialize(request.AdditionalInformation);
                    candidateCurrent.AdditionalInformation = additionalInformation;
                    //Actualiza en la base de datos
                    var isUpdate = await _electionUnitOfWork.GetCandidateRepository().Update(candidateCurrent);
                    //Valida si se pudo guardar
                    if (!isUpdate)
                        throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    //Crea Respuesta
                    var response = _mapper.Map<CandidateUpdateResponse>(candidateCurrent);
                    //Guarda cambios de la transacción
                    await _electionUnitOfWork.CommitAsync().ConfigureAwait(false);
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
