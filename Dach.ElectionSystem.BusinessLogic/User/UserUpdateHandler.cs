
using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Models.Response.User;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.User
{
    public class UserUpdateHandler : IRequestHandler<UserUpdateRequest, UserUpdateResponse>
    {
        #region Constructor
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly ValidateIntegrity validateIntegrity;

        public UserUpdateHandler(
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
        #region Handler
        public async Task<UserUpdateResponse> Handle(UserUpdateRequest request, CancellationToken cancellationToken)
        {
            //Validamos integridad de datos
            var userCurrent = await validateIntegrity.ValidateUser(request);
            //Actualizar datos de usuario 
            UpdateDataUser(request, userCurrent);
            //Actualizar Usuario
            var isUserUpdate = await userRepository.Update(userCurrent);
            if (!isUserUpdate)
                throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            var userResponse = mapper.Map<UserUpdateResponse>(userCurrent);
            return userResponse;
        }

        /// <summary>
        /// Acualiza la información del usuario
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userCurrent"></param>
        private void UpdateDataUser(UserUpdateRequest request, Models.Persitence.User userCurrent)
        {
            var userUpdate = mapper.Map<Models.Persitence.User>(request);
            userCurrent.DNI = userUpdate.DNI;
            userCurrent.FirstName = userUpdate.FirstName;
            userCurrent.SecondLastName = userUpdate.SecondLastName;
            userCurrent.FirstLastName = userUpdate.FirstLastName;
            userCurrent.SecondName = userUpdate.SecondName;
            userCurrent.UserName = userUpdate.UserName;
            userCurrent.BirthDate = userUpdate.BirthDate;
        }
        #endregion
    }
}
