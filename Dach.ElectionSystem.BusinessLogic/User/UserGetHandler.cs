using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq.Expressions;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Models.Response.User;
using Dach.ElectionSystem.Repository.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Dach.ElectionSystem.Services.Data;

namespace Dach.ElectionSystem.BusinessLogic.User
{
    public class UserGetHandler : IRequestHandler<UserGetRequest, UserGetResponse>
    {
        #region Constructor
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly ValidateIntegrity validateIntegrity;

        public UserGetHandler(
            IUserRepository userRepository,
            IMapper mapper,
            ValidateIntegrity validateIntegrity
            )
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.validateIntegrity = validateIntegrity;
        }
        #endregion
        public async Task<UserGetResponse> Handle(UserGetRequest request, CancellationToken cancellationToken)
        {
            await validateIntegrity.ValidateUser(request);
            List<Models.Persitence.User> listUser;
            if (request.Id != null)
                listUser = (await userRepository.GetAsync(u => u.Id == request.Id)).ToList();
            else
                listUser = (await userRepository.GetAsync()).ToList();
            if (request.FirstName != null)
                listUser = (await userRepository.GetAsync(u => u.FirstName == request.FirstName)).ToList();
            if (request.LastName != null)
                listUser = (await userRepository.GetAsync(u => u.FirstLastName == request.LastName)).ToList();
            if (request.Username != null)
                listUser = (await userRepository.GetAsync(u => u.UserName == request.Username)).ToList();
            var listUserGet = mapper.Map<List<Models.Persitence.User>, List<UserResponseBase>>(listUser);
            return new UserGetResponse()
            {
                ListUser = listUserGet
            };
        }
    }
}