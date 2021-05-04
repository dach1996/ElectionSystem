using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Vote;
using Dach.ElectionSystem.Models.Response.Vote;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dach.ElectionSystem.BusinessLogic.Vote
{
    public class VoteUpdateHandler : IRequestHandler<VoteUpdateRequest, VoteUpdateResponse>
    {
        #region Constructor
        private readonly IVoteRepository _VoteRepository;
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity validateIntegrity;

        public VoteUpdateHandler(
            IVoteRepository VoteRepository,
            IMapper mapper,
            ValidateIntegrity validateIntegrity)
        {
            this._VoteRepository = VoteRepository;
            this._mapper = mapper;
            this.validateIntegrity = validateIntegrity;
        }
        #endregion
        #region Handler

        public async Task<VoteUpdateResponse> Handle(VoteUpdateRequest request, CancellationToken cancellationToken)
        {
            //Validamos que exista el Evento
            var eventCurrent = await validateIntegrity.ValidateEvent(request.IdEvent);
            //Validamos que exista el Candidato
            var candidateCurrent = await validateIntegrity.ValidateCandiate(request.IdCandidate);
            if (candidateCurrent.IdEvent != eventCurrent.Id)
                throw new CustomException(Models.Enums.MessageCodesApi.CandidateDontRegister, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
            //Valida que el usuario esté registrado al evento
            var voteCurrent = (await _VoteRepository.GetAsyncInclude(v => v.IdEvent == eventCurrent.Id &&
                                                                             v.IdUser == request.UserContext.Id)).FirstOrDefault();
            if (voteCurrent == null)
                throw new CustomException(Models.Enums.MessageCodesApi.UserNotRegisterEvent, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
            //Valida que el usuario no registre voto
            if (voteCurrent.HasVote)
                throw new CustomException(Models.Enums.MessageCodesApi.UserHasVote, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
            //Guardamos los datos del Voto                                                              
            voteCurrent.IdCandidate = candidateCurrent.Id;
            voteCurrent.DateVote = DateTime.Now;
            voteCurrent.HasVote = true;
            //Registra el voto del usuario
            var isUpdate = await _VoteRepository.Update(voteCurrent);
            if (!isUpdate)
                throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            return _mapper.Map<VoteUpdateResponse>(voteCurrent);
        }
        #endregion


    }
}