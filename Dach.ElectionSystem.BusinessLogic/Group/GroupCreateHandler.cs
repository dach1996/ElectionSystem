using System.Threading;
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
    public class GroupCreateHandler : IRequestHandler<GroupCreateRequest, GroupCreateResponse>
    {
        #region Constructor
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository userRepository;
        private readonly ILogger<GroupCreateHandler> logger;

        public GroupCreateHandler(
            IGroupRepository groupRepository,
            IMapper mapper,
            IUserRepository userRepository,
            ILogger<GroupCreateHandler> logger)
        {
            this._groupRepository = groupRepository;
            this._mapper = mapper;
            this.userRepository = userRepository;
            this.logger = logger;
        }
        #endregion

        #region Handler
        public System.Threading.Tasks.Task<GroupCreateResponse> Handle(GroupCreateRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
        #endregion

    }
}