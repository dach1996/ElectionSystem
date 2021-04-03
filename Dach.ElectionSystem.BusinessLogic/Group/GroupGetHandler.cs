using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dach.ElectionSystem.Models.Request.Group;
using Dach.ElectionSystem.Models.Response.Group;
using Dach.ElectionSystem.Repository.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dach.ElectionSystem.BusinessLogic.Group
{
    /// <summary>
    /// Clase GroupCreateHandler
    /// </summary>
    public class GroupGetHandler : IRequestHandler<GroupGetRequest, GroupGetResponse>
    {
        #region Constructor
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository userRepository;
        private readonly ILogger<GroupGetHandler> logger;

        public GroupGetHandler(
            IGroupRepository groupRepository,
            IMapper mapper,
            IUserRepository userRepository,
            ILogger<GroupGetHandler> logger)
        {
            this._groupRepository = groupRepository;
            this._mapper = mapper;
            this.userRepository = userRepository;
            this.logger = logger;
        }


        #endregion

        #region Handler
        public Task<GroupGetResponse> Handle(GroupGetRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
        #endregion

    }
}