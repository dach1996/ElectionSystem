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
    public class GroupDeleteHandler : IRequestHandler<GroupDeleteRequest, GroupDeleteResponse>
    {
        #region Constructor
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository userRepository;
        private readonly ILogger<GroupDeleteHandler> logger;

        public GroupDeleteHandler(
            IGroupRepository groupRepository,
            IMapper mapper,
            IUserRepository userRepository,
            ILogger<GroupDeleteHandler> logger)
        {
            this._groupRepository = groupRepository;
            this._mapper = mapper;
            this.userRepository = userRepository;
            this.logger = logger;
        }


        #endregion

        #region Handler
        public Task<GroupDeleteResponse> Handle(GroupDeleteRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
        #endregion

    }
}