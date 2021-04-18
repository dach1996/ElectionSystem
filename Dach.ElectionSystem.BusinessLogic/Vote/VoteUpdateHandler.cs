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
        private readonly IUserRepository userRepository;
        private readonly ILogger<VoteUpdateHandler> logger;
        private readonly ValidateIntegrity validateIntegrity;

        public VoteUpdateHandler(
            IVoteRepository VoteRepository,
            IMapper mapper,
            IUserRepository userRepository,
            ILogger<VoteUpdateHandler> logger,
            ValidateIntegrity validateIntegrity)
        {
            this._VoteRepository = VoteRepository;
            this._mapper = mapper;
            this.userRepository = userRepository;
            this.logger = logger;
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
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.DataInconsistency, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);

            var voteCurrent = (await _VoteRepository.GetAsyncInclude(v => v.IdEvent == eventCurrent.Id &&
                                                                             v.IdUser == request.UserContext.Id)).FirstOrDefault();
            //Guardamos los datos del Voto                                                              
            voteCurrent.IdCandidate = candidateCurrent.Id;
            voteCurrent.Date = DateTime.Now;
            voteCurrent.HasVote = true;

            var isUpdate = await _VoteRepository.Update(voteCurrent);
            if (!isUpdate)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            return _mapper.Map<VoteUpdateResponse>(voteCurrent);
        }
        #endregion


    }
}