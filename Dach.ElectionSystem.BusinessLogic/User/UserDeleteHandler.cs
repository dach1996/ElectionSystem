using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Models.Response.User;
using Dach.ElectionSystem.Repository.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.User
{
    public class UserDeleteHandler : IRequestHandler<UserDeleteRequest, UserDeleteResponse>
    {
        #region Constructor
        private readonly ILogger<UserDeleteHandler> logger;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public UserDeleteHandler(
            ILogger<UserDeleteHandler> logger,
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
        public async Task<UserDeleteResponse> Handle(UserDeleteRequest request, CancellationToken cancellationToken)
        {
            var userCurrent = await userRepository.GetByIdAsync(Convert.ToInt32(request.TokenModel.Id));
            if (userCurrent == null)
            {
                logger.LogWarning($"No se encuentra usuario Token con ID:{request.TokenModel.Id}");
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Unauthorized);
            }

            var userToDesactive = await userRepository.GetByIdAsync(Convert.ToInt32(request.Id));
            if (userToDesactive == null)
            {
                
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Unauthorized);
            }
            if (!userToDesactive.IsActive)
            {
                logger.LogWarning($"El usuario con Id: {request.Id} ya está desactivado");
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.UserIsInactive, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Unauthorized);
            }
            userToDesactive.IsActive = false;
            var isUpdate = await userRepository.Update(userToDesactive);
            if (!isUpdate)
            {
                logger.LogWarning($"No se pudo actualizar Usuario");
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Unauthorized);
            }
            return mapper.Map<UserDeleteResponse>(userToDesactive);
        }
        #endregion
    }
}
