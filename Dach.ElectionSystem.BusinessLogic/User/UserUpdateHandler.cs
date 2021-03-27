using AutoMapper;
using AutoMapper.Configuration;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Models.Response.User;
using Dach.ElectionSystem.Repository.Interfaces;
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
        public UserUpdateHandler(
            ILogger<UserUpdateHandler> logger,
            IUserRepository userRepository,
            IMapper mapper
            )
        {
            this.logger = logger;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        #endregion
        #region Handler
        public async Task<UserUpdateResponse> Handle(UserUpdateRequest request, CancellationToken cancellationToken)
        {
            var userCurrent = await userRepository.GetUserByUsernameByEmail(request.TokenModel.Email);
            if (userCurrent == null)
            {
                logger.LogWarning($"Usuario {request.TokenModel.Username} - { request.TokenModel.Email} no se encuentra");
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Unauthorized);
            }
            var validateUsername = await userRepository.GetUserByUsernameByUsername(request.UserName);
            if (validateUsername != null)
                if (validateUsername.Id != userCurrent.Id)
                {
                    logger.LogWarning($"El nombre de usuario {request.UserName} ya se encuentra registrado.");
                    throw new ExceptionCustom(Models.Enums.MessageCodesApi.DataExist, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Unauthorized);
                }
            //Actualizar datos de usuario 
            var userUpdate = mapper.Map<Models.Persitence.User>(request);
            userCurrent.DNI = userUpdate.DNI;
            userCurrent.FirstName = userUpdate.FirstName;
            userCurrent.SecondLastName = userUpdate.SecondLastName;
            userCurrent.FirstLastName = userUpdate.FirstLastName;
            userCurrent.SecondName = userUpdate.SecondName;
            userCurrent.UserName = userUpdate.UserName;
            userCurrent.BirthDate = userUpdate.BirthDate;

            var isUserUpdate = await userRepository.Update(userCurrent);
            if (!isUserUpdate)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            var userResponse = mapper.Map<UserUpdateResponse>(userCurrent);
            return userResponse;
        }
        #endregion
    }
}
