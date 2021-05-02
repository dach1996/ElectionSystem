using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dach.ElectionSystem.Models.Request.Vote;
using Dach.ElectionSystem.Models.Response.Vote;
using Dach.ElectionSystem.Repository.Interfaces;
using MediatR;


namespace Dach.ElectionSystem.BusinessLogic.Vote
{
    public class VoteGetHandler : IRequestHandler<VoteGetRequest, VoteGetResponse>
    {
        #region Constructor
        private readonly IVoteRepository _VoteRepository;
        private readonly IMapper _mapper;

        public VoteGetHandler(
            IVoteRepository VoteRepository,
            IMapper mapper)
        {
            this._VoteRepository = VoteRepository;
            this._mapper = mapper;
        }
        #endregion
        #region Handler
        public async Task<VoteGetResponse> Handle(VoteGetRequest request, CancellationToken cancellationToken)
        {
            var votes = (await _VoteRepository.GetAsync()).ToList();
            return new VoteGetResponse()
            {
                ListVotes =  _mapper.Map<List<VoteResponseBase>>(votes)
            };
        }
        #endregion

    }
}