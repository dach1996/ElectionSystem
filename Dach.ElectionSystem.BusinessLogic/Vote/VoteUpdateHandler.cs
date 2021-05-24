using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Vote;
using Dach.ElectionSystem.Models.Response.Vote;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Repository.UnitOfWork;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dach.ElectionSystem.BusinessLogic.Vote
{
    public class VoteUpdateHandler : IRequestHandler<VoteUpdateRequest, VoteUpdateResponse>
    {
        #region Constructor
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity _validateIntegrity;
        private readonly ILogger<VoteUpdateHandler> _logger;
        private readonly IElectionUnitOfWork _electionUnitOfWork;

        public VoteUpdateHandler(
            IMapper mapper,
            ValidateIntegrity validateIntegrity,
            IElectionUnitOfWork electionUnitOfWork,
            ILogger<VoteUpdateHandler> logger)
        {
            _mapper = mapper;
            _validateIntegrity = validateIntegrity;
            _electionUnitOfWork = electionUnitOfWork;
            _logger = logger;
        }
        #endregion
        #region Handler

        public async Task<VoteUpdateResponse> Handle(VoteUpdateRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                try
                {
                    await _electionUnitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                    //Validamos que exista el Evento
                    var eventCurrent = await _validateIntegrity.ValidateEvent(request.IdEvent);
                    //Validar la fecha máxima para realizar votación
                    var isDateValid = eventCurrent.DateMinVote <= DateTime.Now && eventCurrent.DateMaxVote >= DateTime.Now;
                    if (!isDateValid)
                        throw new CustomException(Models.Enums.MessageCodesApi.IncorrectDates, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadGateway,
                                                    $"Las fechas máximas para la votación ha terminado: Min: {eventCurrent.DateMinVote} - Max:  {eventCurrent.DateMaxVote}");
                    //Validamos que exista el Candidato
                    var candidateCurrent = await _validateIntegrity.ValidateCandiate(request.IdCandidate);
                    if (candidateCurrent.IdEvent != eventCurrent.Id)
                        throw new CustomException(Models.Enums.MessageCodesApi.CandidateDontRegister, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
                    //Valida que el usuario esté registrado al evento y sea el mismo que envía el request
                    var voteCurrent = await _validateIntegrity.ValidateVote(request.IdEvent, request.UserContext.Id);
                    //Valida que el usuario no registre voto
                    if (voteCurrent.HasVote)
                        throw new CustomException(Models.Enums.MessageCodesApi.UserHasVote, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
                    //Guardamos los datos del Voto                                                              
                    voteCurrent.IdCandidate = candidateCurrent.Id;
                    voteCurrent.DateVote = DateTime.Now;
                    voteCurrent.HasVote = true;
                    //Registra el voto del usuario
                    var isUpdate = await _electionUnitOfWork.GetVoteRepository().Update(voteCurrent);
                    if (!isUpdate)
                        throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    await _electionUnitOfWork.CommitAsync().ConfigureAwait(false);
                    return _mapper.Map<VoteUpdateResponse>(voteCurrent);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error en {@Class}({@Method}): {@Message}", nameof(VoteUpdateHandler), nameof(Handle), ex.Message);
                    await _electionUnitOfWork.RollBackAsync().ConfigureAwait(false);
                    throw;
                }
            }

        }
        #endregion


    }
}