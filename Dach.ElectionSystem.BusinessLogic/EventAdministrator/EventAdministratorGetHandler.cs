using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dach.ElectionSystem.Models.Request.EventAdministrator;
using Dach.ElectionSystem.Models.Response.EventAdministrator;
using Dach.ElectionSystem.Repository.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dach.ElectionSystem.BusinessLogic.EventAdministrator
{
    public class EventAdministratorGetHandler : IRequestHandler<EventAdministratorGetRequest, EventAdministratorGetResponse>
    {
        #region Constructor
        private readonly IEventAdministratorRepository _eventAdministratorRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository userRepository;
        private readonly ILogger<EventAdministratorGetHandler> logger;

        public EventAdministratorGetHandler(
            IEventAdministratorRepository EventAdministratorRepository,
            IMapper mapper,
            IUserRepository userRepository,
            ILogger<EventAdministratorGetHandler> logger)
        {
            this._eventAdministratorRepository = EventAdministratorRepository;
            this._mapper = mapper;
            this.userRepository = userRepository;
            this.logger = logger;
        }
        #endregion
        #region Handler
        public async Task<EventAdministratorGetResponse> Handle(EventAdministratorGetRequest request, CancellationToken cancellationToken)
        {
           return null;
        }
        #endregion

    }
}