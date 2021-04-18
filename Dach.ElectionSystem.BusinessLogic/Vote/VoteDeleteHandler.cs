using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.Vote;
using Dach.ElectionSystem.Models.Response.Vote;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.Vote
{
    public class VoteDeleteHandler : IRequestHandler<VoteDeleteRequest, VoteDeleteResponse>
    {
        #region Constructor
        private readonly IVoteRepository _VoteRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository userRepository;
        private readonly ValidateIntegrity validateIntegrity;

        public VoteDeleteHandler(
            IVoteRepository VoteRepository,
            IMapper mapper,
            IUserRepository userRepository,
            ValidateIntegrity validateIntegrity)
        {
            this._VoteRepository = VoteRepository;
            this._mapper = mapper;
            this.userRepository = userRepository;
            this.validateIntegrity = validateIntegrity;
        }
        #endregion
        #region Handler
        public async Task<VoteDeleteResponse> Handle(VoteDeleteRequest request, CancellationToken cancellationToken)
        {
            //Validamos que exista el Evento
            var eventCurrent = await validateIntegrity.ValidateEvent(request.IdEvent);
            //Validamos que exista el Candidato
            var voteCurrent = (await _VoteRepository.GetAsyncInclude(v=> v.IdEvent == eventCurrent.Id &&
                                                                    v.IdUser == request.UserContext.Id)).FirstOrDefault();
            if (voteCurrent == null)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotFindRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);

            voteCurrent.IsActive=false;
            var isUpdate = await _VoteRepository.Update(voteCurrent);
            if (!isUpdate)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotDeleteRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            return _mapper.Map<VoteDeleteResponse>(voteCurrent);
        }
        #endregion

    }
}
