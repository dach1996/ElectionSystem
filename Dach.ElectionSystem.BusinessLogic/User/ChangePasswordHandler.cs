using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Repository.UnitOfWork;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.User
{
    public class ChangePasswordHandler : IRequestHandler<ChangePasswordRequest, Unit>
    {
        #region Constructor
        private readonly IElectionUnitOfWork _electionUnitOfWork;
        private readonly IConfiguration _configuration;
        private readonly ValidateIntegrity _validateIntegrity;

        public ChangePasswordHandler(
            IConfiguration configuration,
            ValidateIntegrity validateIntegrity,
            IElectionUnitOfWork electionUnitOfWork)
        {
            _configuration = configuration;
            _validateIntegrity = validateIntegrity;
            _electionUnitOfWork = electionUnitOfWork;
        }
        #endregion

        #region Handler
        public async Task<Unit> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                try
                {
                    await _electionUnitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                    var _secretKey = _configuration.GetSection("SecretKey").Value;
                    //Traermos el usuario en contexto
                    var userCurrent = await _validateIntegrity.ValidateUser(request);
                    //Encriptamos la contraseña
                    var newPassword = Common.Util.ComputeSHA256(request.NewPassword, _secretKey);
                    //Actualizamos al Usuario
                    userCurrent.Password = newPassword;
                    var isUserUpdate = await _electionUnitOfWork.GetUserRepository().Update(userCurrent);
                    if (!isUserUpdate)
                        throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    await _electionUnitOfWork.CommitAsync().ConfigureAwait(false);
                    return Unit.Value;
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
