using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Vote;
using Dach.ElectionSystem.Models.Response.Vote;
using Dach.ElectionSystem.Repository.UnitOfWork;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.Vote
{
    public class VoteDesactiveHandler : IRequestHandler<VoteDeleteRequest, VoteDeleteResponse>
    {
        #region Constructor
        private readonly ILogger<VoteDesactiveHandler> _logger;
        private readonly IElectionUnitOfWork _electionUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity _validateIntegrity;

        public VoteDesactiveHandler(
            IMapper mapper,
            ValidateIntegrity validateIntegrity,
            IElectionUnitOfWork electionUnitOfWork,
            ILogger<VoteDesactiveHandler> logger)
        {
            _mapper = mapper;
            _validateIntegrity = validateIntegrity;
            _electionUnitOfWork = electionUnitOfWork;
            _logger = logger;
        }
        #endregion
        #region Handler
        public async Task<VoteDeleteResponse> Handle(VoteDeleteRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                try
                {
                    await _electionUnitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                    //Validamos que exista el Evento
                    _ = await _validateIntegrity.ValidateEvent(request.IdEvent);
                    //Validamos que exista el voto
                    var voteCurrent = await _validateIntegrity.ValidateVote(request.IdEvent, request.UserContext.Id);
                    //Valida que el usuario que envía el request sea administrador del evento
                    await _validateIntegrity.IsAdministratorEvent(request.IdUser, request.IdEvent);
                    //Valida que el participante no haya realizaco su voto
                    if (!voteCurrent.HasVote)
                        throw new CustomException(Models.Enums.MessageCodesApi.UserHasVote, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.BadRequest,"No se puede desactivar un usuario que ya participó");
                    //Desactiva el participante
                    voteCurrent.IsActive = !voteCurrent.IsActive;
                    var isUpdate = await _electionUnitOfWork.GetVoteRepository().Update(voteCurrent);
                    //Actualiza información
                    if (!isUpdate)
                        throw new CustomException(Models.Enums.MessageCodesApi.NotDeleteRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    //Guarda los cambios
                    await _electionUnitOfWork.CommitAsync().ConfigureAwait(false);
                    //Retorna el mensaje de respuesta
                    return _mapper.Map<VoteDeleteResponse>(voteCurrent);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error en {@Class}({@Method}): {@Message}", nameof(VoteDeleteResponse), nameof(Handle), ex.Message);
                    await _electionUnitOfWork.RollBackAsync().ConfigureAwait(false);
                    throw;
                }
            }
        }
        #endregion
    }
}
