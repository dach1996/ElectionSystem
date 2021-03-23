using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Models.Response.User;
using Dach.ElectionSystem.Repository.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.User
{
    public class UserCreateHandler : IRequestHandler<UserCreateRequest, UserCreateResponse>
    {
        private readonly ILogger<UserCreateHandler> logger;
        private readonly IUserRepository userRepository;

        public UserCreateHandler(ILogger<UserCreateHandler> logger, IUserRepository userRepository)
        {
            this.logger = logger;
            this.userRepository = userRepository;
        }
        public Task<UserCreateResponse> Handle(UserCreateRequest request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
