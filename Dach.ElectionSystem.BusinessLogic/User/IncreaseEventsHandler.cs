using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Models.Response.User;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.User
{
    public class IncreaseEventsHandler : IRequestHandler<IncreaseEventsRequest, Unit>
    {
        #region Constructor
        private readonly ILogger<UserCreateHandler> logger;
        private readonly IUserRepository userRepository;
        private readonly IConfiguration _configuration;
        private readonly ValidateIntegrity validateIntegrity;

        public IncreaseEventsHandler(
            ILogger<UserCreateHandler> logger,
            IUserRepository userRepository,
            IConfiguration configuration,
            ValidateIntegrity validateIntegrity)
        {
            this.logger = logger;
            this.userRepository = userRepository;
            _configuration = configuration;
            this.validateIntegrity = validateIntegrity;
        }
        #endregion

        #region Handler
        public async Task<Unit> Handle(IncreaseEventsRequest request, CancellationToken cancellationToken)
        {
            // Validamos al usuario que está solicitando el servicio
            await validateIntegrity.ValidateUser(request);
            //Validamos los datos para el servicio
            var userService = _configuration.GetSection("NumberEvents:User").Value;
            var passwordService = _configuration.GetSection("NumberEvents:Password").Value;
            var _secretKey = _configuration.GetSection("SecretKey").Value;
            var passHash = Common.Util.ComputeSHA256(request.PasswordToService, _secretKey);
            if (!(userService == request.UserToService && passHash == passwordService))
                throw new CustomException(Models.Enums.MessageCodesApi.NotAuthorization, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Unauthorized);
            //Incrementamos los eventos permitidos al usuario
            var userToIncreaseEvents = await validateIntegrity.ValidateUser(request.IdUserToIncreaseEvent);
            userToIncreaseEvents.EventNumber.NumberMaxEvent = request.NumberEvent;
            //Guardamos cambios
            var isUserUpdate = await userRepository.Update(userToIncreaseEvents);
            if (!isUserUpdate)
                throw new CustomException(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            logger.LogInformation($"Se actualizó los eventos del usuario {userToIncreaseEvents.UserName} a: {userToIncreaseEvents.EventNumber.NumberMaxEvent} Eventos");
            return Unit.Value;
        }
        #endregion
    }
}
