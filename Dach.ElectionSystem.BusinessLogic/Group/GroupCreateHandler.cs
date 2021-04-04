using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
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
        private readonly IEventRepository _eventRepository;
        private readonly ILogger<GroupCreateHandler> logger;

        public GroupCreateHandler(
            IGroupRepository groupRepository,
            IMapper mapper,
            IUserRepository userRepository,
            IEventRepository eventRepository,
            ILogger<GroupCreateHandler> logger)
        {
            this._groupRepository = groupRepository;
            this._mapper = mapper;
            this.userRepository = userRepository;
            this._eventRepository = eventRepository;
            this.logger = logger;
        }
        #endregion

        #region Handler
        public async Task<GroupCreateResponse> Handle(GroupCreateRequest request, CancellationToken cancellationToken)
        {
            var eventCurrent = (await _eventRepository.GetAsync(e => e.Id == request.IdEvent)).First();
            if (eventCurrent == null)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotFindRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
            var groupCurrent = _mapper.Map<Models.Persitence.Group>(request);
            groupCurrent.Event = eventCurrent;
            var isCreateGroup = await _groupRepository.CreateAsync(groupCurrent);
            if (!isCreateGroup)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotCreateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
            return _mapper.Map<GroupCreateResponse>(groupCurrent);
        }
        #endregion

    }
}