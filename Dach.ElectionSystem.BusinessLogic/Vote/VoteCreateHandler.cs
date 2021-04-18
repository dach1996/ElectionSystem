using System;
using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Models.Request.Vote;
using Dach.ElectionSystem.Models.Response.Vote;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.Vote
{
    public class VoteCreateHandler : IRequestHandler<VoteCreateRequest, VoteCreateResponse>
    {
        #region Constructor 
        private readonly IVoteRepository _VoteRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository userRepository;
        private readonly ValidateIntegrity validateIntegrity;

        public VoteCreateHandler(
        IVoteRepository VoteRepository,
        IMapper mapper,
        IUserRepository userRepository,
        ValidateIntegrity validateIntegrity
        )
        {
            this._VoteRepository = VoteRepository;
            this._mapper = mapper;
            this.userRepository = userRepository;
            this.validateIntegrity = validateIntegrity;
        }
        #endregion
        #region Handler
        public async Task<VoteCreateResponse> Handle(VoteCreateRequest request, CancellationToken cancellationToken)
        {
            //Validamos que exista el Evento
            var eventCurrent = await validateIntegrity.ValidateEvent(request.IdEvent);
            //Validamos que exista el Candidato
              var newVote = new Models.Persitence.Vote()
            {
                IdEvent = eventCurrent.Id,
                IdUser = request.UserContext.Id,
                IsActive = true,
            };
            var isCreate = await _VoteRepository.CreateAsync(newVote);
            if (!isCreate)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotCreateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            return _mapper.Map<VoteCreateResponse>(newVote);
        }
        #endregion
    }
}
