using AutoMapper;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Services.Data;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.User
{
    public class ChangePasswordHandler : IRequestHandler<ChangePasswordRequest,Unit>
    {
        #region Constructor
        private readonly ILogger<UserCreateHandler> logger;
        private readonly IUserRepository userRepository;
        private readonly string _secretKey;
        private readonly IConfiguration _configuration;
        private readonly ValidateIntegrity validateIntegrity;

        public ChangePasswordHandler(
            ILogger<UserCreateHandler> logger,
            IUserRepository userRepository,
            IConfiguration configuration,
            ValidateIntegrity validateIntegrity)
        {
            this.logger = logger;
            this.userRepository = userRepository;
            _configuration = configuration;
            this.validateIntegrity = validateIntegrity;
            _secretKey = _configuration.GetSection("SecretKey").Value;
        }
        #endregion

        #region Handler
        public async Task<Unit> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            //Traermos el usuario en contexto
            var userCurrent = await validateIntegrity.ValidateUser(request);
            //Encriptamos la contraseña
            var newPassword = Common.Util.ComputeSHA256(request.NewPassword, _secretKey);
            //Actualizamos al Usuario
            userCurrent.Password = newPassword;
             var isUserUpdate = await userRepository.Update(userCurrent);
            if (!isUserUpdate)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.NotUpdateRecord, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.InternalServerError);
            return Unit.Value;
        }
        #endregion
    }
}
