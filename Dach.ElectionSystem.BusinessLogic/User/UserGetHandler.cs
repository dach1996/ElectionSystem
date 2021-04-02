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

namespace Dach.ElectionSystem.BusinessLogic.User
{
    public class UserGetHandler : IRequestHandler<UserGetRequest, UserGetResponse>
    {
        #region Constructor
        private readonly ILogger<UserGetHandler> logger;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public UserGetHandler(
            ILogger<UserGetHandler> logger,
            IUserRepository userRepository,
            IMapper mapper
            )
        {
            this.logger = logger;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        #endregion
        public async Task<UserGetResponse> Handle(UserGetRequest request, CancellationToken cancellationToken)
        {
            var userCurrent = await userRepository.GetUserByUsernameByEmail(request.TokenModel.Email);
            if (userCurrent == null)
            {
                logger.LogWarning($"No se encuentra usuario Token con ID:{request.TokenModel.Id}");
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Unauthorized);
            }
            var listUser = new List<Models.Persitence.User>();
            if (request.Id != null)
                listUser = (await userRepository.GetAsync(u => u.Id == request.Id)).ToList();
            if (request.FirstName != null)
                listUser = (await userRepository.GetAsync(u => u.FirstName == request.FirstName)).ToList();
            if (request.LastName != null)
                listUser = (await userRepository.GetAsync(u => u.FirstLastName == request.LastName)).ToList();
            if (request.Username != null)
                listUser = (await userRepository.GetAsync(u => u.UserName == request.Username)).ToList();
             var listUserGet = mapper.Map<List<Models.Persitence.User>,List<UserResponseBase>>(listUser);
            return  new UserGetResponse(){
                ListUser = listUserGet
            };
        }
    }
}