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
    public class GroupDeleteHandler : IRequestHandler<GroupDeleteRequest, GroupDeleteResponse>
    {
        #region Constructor
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository userRepository;
        private readonly ILogger<GroupDeleteHandler> logger;
        private readonly IEventRepository _eventRepository;

        public GroupDeleteHandler(
            IGroupRepository groupRepository,
            IMapper mapper,
            IUserRepository userRepository,
            ILogger<GroupDeleteHandler> logger,
            IEventRepository eventRepository)
        {
            this._groupRepository = groupRepository;
            this._mapper = mapper;
            this.userRepository = userRepository;
            this.logger = logger;
            _eventRepository = eventRepository;
        }


        #endregion

        #region Handler
        public async Task<GroupDeleteResponse> Handle(GroupDeleteRequest request, CancellationToken cancellationToken)
        {
           var eventCurrent = (await _eventRepository.GetAsync(e => e.Id == request.IdEvent)).FirstOrDefault();
            if (eventCurrent == null)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotFindRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
            var groupCurrent = (await _groupRepository.GetAsync(g => g.Id == request.IdGroup)).FirstOrDefault();
            if (groupCurrent == null)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotFindRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
            groupCurrent.IsActive=false;
             var isDesactiveGroup = await _groupRepository.Update(groupCurrent);
            if (!isDesactiveGroup)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
            return _mapper.Map<GroupDeleteResponse>(groupCurrent);
        }
        #endregion

    }
}