using System.Collections.Generic;
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
    public class GroupGetHandler : IRequestHandler<GroupGetRequest, GroupGetResponse>
    {
        #region Constructor
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository userRepository;
        private readonly ILogger<GroupGetHandler> logger;
        private readonly IEventRepository _eventRepository;

        public GroupGetHandler(
            IGroupRepository groupRepository,
            IMapper mapper,
            IUserRepository userRepository,
            ILogger<GroupGetHandler> logger,
            IEventRepository eventRepository)
        {
            this._groupRepository = groupRepository;
            this._mapper = mapper;
            this.userRepository = userRepository;
            this.logger = logger;
            this._eventRepository = eventRepository;
        }


        #endregion

        #region Handler
        public async Task<GroupGetResponse> Handle(GroupGetRequest request, CancellationToken cancellationToken)
        {
            var listGroups = new List<Models.Persitence.Group>();
            if (request.IdEvent != null)
            {
                var eventCurrent = (await _eventRepository.GetAsync(e => e.Id == request.IdEvent)).FirstOrDefault();
                if (eventCurrent == null)
                    throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotFindRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
                listGroups = (await _groupRepository.GetAsync(e => e.IdEvent == request.IdEvent)).ToList();
            }
            if (request.IdGroup != null)
            {
                var groupCurrent = (await _groupRepository.GetAsync(g => g.Id == request.IdGroup)).FirstOrDefault();
                if (groupCurrent == null)
                    throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotFindRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Conflict);
               listGroups = (await _groupRepository.GetAsync(e => e.Id == request.IdGroup)).ToList();
            }
            if (request.IdEvent == null && request.IdGroup == null)
                listGroups = (await _groupRepository.GetAsync()).ToList();
           return
             new GroupGetResponse()
             {
                 ListGroups = _mapper.Map<List<GroupBaseResponse>>(listGroups)
             };

        }
        #endregion

    }
}