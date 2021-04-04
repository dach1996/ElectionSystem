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
    public class GroupUpdateHandler : IRequestHandler<GroupUpdateRequest, GroupUpdateResponse>
    {
        #region Constructor
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository userRepository;
        private readonly ILogger<GroupUpdateHandler> logger;
        private readonly IEventRepository eventRepository;

        public GroupUpdateHandler(
            IGroupRepository groupRepository,
            IMapper mapper,
            IUserRepository userRepository,
            ILogger<GroupUpdateHandler> logger,
            IEventRepository eventRepository)
        {
            this._groupRepository = groupRepository;
            this._mapper = mapper;
            this.userRepository = userRepository;
            this.logger = logger;
            this.eventRepository = eventRepository;
        }
        #endregion

        #region Handler
        public async Task<GroupUpdateResponse> Handle(GroupUpdateRequest request, CancellationToken cancellationToken)
        {
            var eventCurrent = (await eventRepository.GetAsync(e => e.Id == request.IdEvent)).FirstOrDefault();
            if (eventCurrent == null)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotFindRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
            var groupCurrent = (await _groupRepository.GetAsync(g => g.Id == request.IdGroup)).FirstOrDefault();
            if (groupCurrent == null)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotFindRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
            groupCurrent.Details = request.Details;
            groupCurrent.Image = request.Image;
            groupCurrent.IsActive = request.IsActive;
            groupCurrent.MaxCandidate = request.MaxCandidate;
            groupCurrent.Name = request.Name;

            var isUpdateGroup = await _groupRepository.Update(groupCurrent);
            if (!isUpdateGroup)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
            return _mapper.Map<GroupUpdateResponse>(groupCurrent);
        }
        #endregion

    }
}