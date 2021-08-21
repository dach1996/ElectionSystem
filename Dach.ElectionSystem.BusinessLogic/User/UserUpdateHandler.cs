
using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Models.Response.User;
using Dach.ElectionSystem.Repository.UnitOfWork;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.User
{
    public class UserUpdateHandler : IRequestHandler<UserUpdateRequest, UserUpdateResponse>
    {
        #region Constructor
        private readonly IMapper _mapper;
        private readonly ValidateIntegrity _validateIntegrity;
        private readonly ILogger<UserUpdateHandler> _logger;
        private readonly IElectionUnitOfWork _electionUnitOfWork;

        public UserUpdateHandler(
            IMapper mapper,
            ValidateIntegrity validateIntegrity,
            IElectionUnitOfWork electionUnitOfWork,
            ILogger<UserUpdateHandler> logger)
        {
            _mapper = mapper;
            _validateIntegrity = validateIntegrity;
            _electionUnitOfWork = electionUnitOfWork;
            _logger = logger;
        }
        #endregion
        #region Handler
        public async Task<UserUpdateResponse> Handle(UserUpdateRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                try
                {
                    await _electionUnitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                    //Validamos integridad de datos
                    var userCurrent = await _validateIntegrity.ValidateUser(request);
                    //Actualizar datos de usuario 
                    UpdateDataUser(request, userCurrent);
                    //Actualizar Usuario
                    var isUserUpdate = await _electionUnitOfWork.GetUserRepository().Update(userCurrent);
                    if (!isUserUpdate)
                        throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    var userResponse = _mapper.Map<UserUpdateResponse>(userCurrent);
                    await _electionUnitOfWork.CommitAsync().ConfigureAwait(false);
                    return userResponse;
                }
                catch (Exception)
                {
                    await _electionUnitOfWork.RollBackAsync().ConfigureAwait(false);
                    throw;
                }
            }
        }

        /// <summary>
        /// Acualiza la información del usuario
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userCurrent"></param>
        private void UpdateDataUser(UserUpdateRequest request, Models.Persitence.User userCurrent)
        {
            var userUpdate = _mapper.Map<Models.Persitence.User>(request);
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
