using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Models.Response.User;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Repository.UnitOfWork;
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
        private readonly ILogger<UserDeleteHandler> _logger;
        private readonly IElectionUnitOfWork _electionUnitOfWork;
        private readonly IMapper _mapper;
        public UserDeleteHandler(
            ILogger<UserDeleteHandler> logger,
            IMapper mapper,
            IElectionUnitOfWork electionUnitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _electionUnitOfWork = electionUnitOfWork;
        }
        #endregion
        #region Handler
        public async Task<UserDeleteResponse> Handle(UserDeleteRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                try
                {
                    await _electionUnitOfWork.BeginTransactionAsync().ConfigureAwait(false);

                    var userCurrent = await _electionUnitOfWork.GetUserRepository().GetByIdAsync(Convert.ToInt32(request.TokenModel.Id));
                    if (userCurrent == null)
                    {
                        _logger.LogWarning($"No se encuentra usuario Token con ID:{request.TokenModel.Id}");
                        throw new CustomException(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Unauthorized);
                    }

                    var userToDesactive = await _electionUnitOfWork.GetUserRepository().GetByIdAsync(Convert.ToInt32(request.Id));
                    if (userToDesactive == null)
                        throw new CustomException(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Unauthorized);

                    if (!userToDesactive.IsActive)
                    {
                        _logger.LogWarning($"El usuario con Id: {request.Id} ya está desactivado");
                        throw new CustomException(Models.Enums.MessageCodesApi.UserIsInactive, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Unauthorized);
                    }
                    userToDesactive.IsActive = false;
                    var isUpdate = await _electionUnitOfWork.GetUserRepository().Update(userToDesactive);
                    if (!isUpdate)
                    {
                        _logger.LogWarning($"No se pudo actualizar Usuario");
                        throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Unauthorized);
                    }
                    await _electionUnitOfWork.CommitAsync().ConfigureAwait(false);
                    return _mapper.Map<UserDeleteResponse>(userToDesactive);

                }
                catch (Exception)
                {
                    await _electionUnitOfWork.RollBackAsync().ConfigureAwait(false);
                    throw;
                }
            }

        }
        #endregion
    }
}
