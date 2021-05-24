using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Repository.UnitOfWork;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.User
{
    public class IncreaseEventsHandler : IRequestHandler<IncreaseEventsRequest, Unit>
    {
        #region Constructor
        private readonly ILogger<IncreaseEventsHandler> _logger;
        private readonly IElectionUnitOfWork _electionUnitOfWork;
        private readonly IConfiguration _configuration;
        private readonly ValidateIntegrity _validateIntegrity;

        public IncreaseEventsHandler(
            ILogger<IncreaseEventsHandler> logger,
            IConfiguration configuration,
            ValidateIntegrity validateIntegrity,
            IElectionUnitOfWork electionUnitOfWork)
        {
            _logger = logger;
            _configuration = configuration;
            _validateIntegrity = validateIntegrity;
            _electionUnitOfWork = electionUnitOfWork;
        }
        #endregion

        #region Handler
        public async Task<Unit> Handle(IncreaseEventsRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                try
                {
                    await _electionUnitOfWork.BeginTransactionAsync().ConfigureAwait(false);
                    // Validamos al usuario que está solicitando el servicio
                    await _validateIntegrity.ValidateUser(request);
                    //Validamos los datos para el servicio
                    var userService = _configuration.GetSection("NumberEvents:User").Value;
                    var passwordService = _configuration.GetSection("NumberEvents:Password").Value;
                    var _secretKey = _configuration.GetSection("SecretKey").Value;
                    var passHash = Common.Util.ComputeSHA256(request.PasswordToService, _secretKey);
                    if (!(userService == request.UserToService && passHash == passwordService))
                        throw new CustomException(Models.Enums.MessageCodesApi.NotAuthorization, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Unauthorized);
                    //Incrementamos los eventos permitidos al usuario
                    var userToIncreaseEvents = await _validateIntegrity.ValidateUser(request.IdUserToIncreaseEvent);
                    userToIncreaseEvents.EventNumber.NumberMaxEvent = request.NumberEvent;
                    //Guardamos cambios
                    var isUserUpdate = await _electionUnitOfWork.GetUserRepository().Update(userToIncreaseEvents);
                    if (!isUserUpdate)
                        throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
                    _logger.LogInformation($"Se actualizó los eventos del usuario {userToIncreaseEvents.UserName} a: {userToIncreaseEvents.EventNumber.NumberMaxEvent} Eventos");
                    await _electionUnitOfWork.CommitAsync().ConfigureAwait(false);
                    return Unit.Value;

                }
                catch (System.Exception ex)
                {
                    _logger.LogError(ex, "Error en {@Class}({@Method}): {@Message}", nameof(IncreaseEventsHandler), nameof(Handle), ex.Message);
                    await _electionUnitOfWork.RollBackAsync().ConfigureAwait(false);
                    throw;
                }
            }
        }
        #endregion
    }
}
