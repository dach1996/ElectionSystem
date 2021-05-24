using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dach.ElectionSystem.Models.Request.Vote;
using Dach.ElectionSystem.Models.Response.Vote;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Repository.UnitOfWork;
using Dach.ElectionSystem.Services.Data;
using MediatR;


namespace Dach.ElectionSystem.BusinessLogic.Vote
{
    public class VoteGetHandler : IRequestHandler<VoteGetRequest, VoteGetResponse>
    {
        #region Constructor
        private readonly IElectionUnitOfWork _electionUnitOfWork;
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity _validateIntegrity;

        public VoteGetHandler(
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
        public async Task<VoteGetResponse> Handle(VoteGetRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                _=_validateIntegrity.HasRegisterWithEvent(request.UserContext.Id, request.IdEvent);
                var votes = (await _electionUnitOfWork.GetVoteRepository().GetAsync(votes => votes.IdEvent == request.IdEvent)).ToList();
                var NumberParticipantsWithOutVote = votes.Count(p => !p.HasVote && p.IsActive);
                var NumberParticipantsWithVote = votes.Count(p => p.HasVote && p.IsActive);
                var NumberParticipantsActive = votes.Count(p => p.IsActive);
                var NumberParticipantsDesactive = votes.Count(p => !p.IsActive);

                votes = votes.OrderByDescending(e => e.Id)
                .Skip(request.Offset)
                .Take(request.Limit)
                .ToList();

                return new VoteGetResponse()
                {
                    ListVotes = _mapper.Map<List<VoteResponseBase>>(votes),
                    NumberParticipantsActive = NumberParticipantsActive,
                    NumberParticipantsDesactive = NumberParticipantsDesactive,
                    NumberParticipantsWithOutVote = NumberParticipantsWithOutVote,
                    NumberParticipantsWithVote = NumberParticipantsWithVote
                };
            }
        }
        #endregion
    }
}