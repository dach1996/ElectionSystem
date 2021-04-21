using System.Linq;

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.EventAdministrator;
using Dach.ElectionSystem.Models.Response.EventAdministrator;
using Dach.ElectionSystem.Repository.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dach.ElectionSystem.BusinessLogic.EventAdministrator
{
    public class EventAdministratorUpdateHandler : IRequestHandler<EventAdministratorUpdateRequest, EventAdministratorUpdateResponse>
    {
        #region Constructor
        private readonly IEventAdministratorRepository _EventAdministratorRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository userRepository;
        private readonly ILogger<EventAdministratorUpdateHandler> logger;

        public EventAdministratorUpdateHandler(
            IEventAdministratorRepository EventAdministratorRepository,
            IMapper mapper,
            IUserRepository userRepository,
            ILogger<EventAdministratorUpdateHandler> logger)
        {
            this._EventAdministratorRepository = EventAdministratorRepository;
            this._mapper = mapper;
            this.userRepository = userRepository;
            this.logger = logger;
        }
        #endregion
        #region Handler

        public async Task<EventAdministratorUpdateResponse> Handle(EventAdministratorUpdateRequest request, CancellationToken cancellationToken)
        {
           return null;
        }
        #endregion


    }
}