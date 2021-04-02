using System;
using AutoMapper;
using AutoMapper.Configuration;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Models.Response.User;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.User
{
    public class UserUpdateHandler : IRequestHandler<UserUpdateRequest, UserUpdateResponse>
    {
        #region Constructor
        private readonly ILogger<UserUpdateHandler> logger;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly ValidateIntegrity validateIntegrity;

        public UserUpdateHandler(
            ILogger<UserUpdateHandler> logger,
            IUserRepository userRepository,
            IMapper mapper,
            ValidateIntegrity validateIntegrity
            )
        {
            this.logger = logger;
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.validateIntegrity = validateIntegrity;
        }
        #endregion
        #region Handler
        public async Task<UserUpdateResponse> Handle(UserUpdateRequest request, CancellationToken cancellationToken)
        {
            //Validamos integridad de datos
             var userCurrent = await validateIntegrity.ValidateUser(request);     
            //Actualizar datos de usuario 
            var userUpdate = mapper.Map<Models.Persitence.User>(request);
            userCurrent.DNI = userUpdate.DNI;
            userCurrent.FirstName = userUpdate.FirstName;
            userCurrent.SecondLastName = userUpdate.SecondLastName;
            userCurrent.FirstLastName = userUpdate.FirstLastName;
            userCurrent.SecondName = userUpdate.SecondName;
            userCurrent.UserName = userUpdate.UserName;
            userCurrent.BirthDate = userUpdate.BirthDate;
            userCurrent.Password = userUpdate.Password;
            var isUserUpdate = await userRepository.Update(userCurrent);
            if (!isUserUpdate)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            var userResponse = mapper.Map<UserUpdateResponse>(userCurrent);
            return userResponse;
        }
        #endregion
    }
}
