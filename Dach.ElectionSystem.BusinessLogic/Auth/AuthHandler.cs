using System.Linq;
using Dach.ElectionSystem.Models.Auth;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Response.Auth;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Services.TokenJWT;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Dach.ElectionSystem.Repository.UnitOfWork;

namespace Dach.ElectionSystem.BusinessLogic.Auth
{
    public class AuthHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        #region Constructor
        private readonly ITokenService _tokenService;
        private readonly ILogger<AuthHandler> logger;
        private readonly IElectionUnitOfWork _electionUnitOfWork;
        private readonly string _secretKey;

        public AuthHandler(
            ITokenService tokenService,
            IConfiguration configuration,
            ILogger<AuthHandler> logger,
            IElectionUnitOfWork electionUnitOfWork)
        {
            _tokenService = tokenService;
            this.logger = logger;
            _electionUnitOfWork = electionUnitOfWork;
            _secretKey = configuration.GetSection("SecretKey").Value;
        }

        #endregion
        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            using (_electionUnitOfWork)
            {
                var passwordHash = Common.Util.ComputeSHA256(request.Password, _secretKey);
                var user = (await _electionUnitOfWork.GetUserRepository().GetAsync(u => u.Email == request.Email && (u.Password == passwordHash || u.TemPassword == passwordHash))).FirstOrDefault();
                if (user == null)
                    throw new CustomException(Models.Enums.MessageCodesApi.IncorrectData, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Unauthorized);
                if (!user.IsActive)
                    throw new CustomException(Models.Enums.MessageCodesApi.UserIsInactive, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Unauthorized);
                var token = _tokenService.GenerateTokenJwt(user);
                logger.LogWarning($"El usuario {user} ha logeado ");
                return new LoginResponse() { Token = token };
            }
        }
    }
}
