using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.EventAdministrator;
using Dach.ElectionSystem.Models.Response.EventAdministrator;
using Dach.ElectionSystem.Repository.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.EventAdministrator
{
    public class EventAdministratorDeleteHandler : IRequestHandler<EventAdministratorDeleteRequest, EventAdministratorDeleteResponse>
    {
        #region Constructor
        private readonly IEventAdministratorRepository _EventAdministratorRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository userRepository;

        public EventAdministratorDeleteHandler(
            IEventAdministratorRepository EventAdministratorRepository,
            IMapper mapper,
            IUserRepository userRepository)
        {
            this._EventAdministratorRepository = EventAdministratorRepository;
            this._mapper = mapper;
            this.userRepository = userRepository;
        }
        #endregion
        #region Handler
        public async Task<EventAdministratorDeleteResponse> Handle(EventAdministratorDeleteRequest request, CancellationToken cancellationToken)
        {

           
             
            return null;
        }
        #endregion

    }
}
