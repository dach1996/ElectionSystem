using Dach.ElectionSystem.Models.Auth;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Models.Response.Auth;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Services.TokenJWT;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.Auth
{
    [AllowAnonymous]
    public class AuthHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        #region Constructor
        private readonly ITokenService _tokenService;
        private readonly ILogger<AuthHandler> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _secretKey;
        #endregion
        
        public AuthHandler(IMediator mediator,
            IUserRepository usuarioRepository, 
            ITokenService tokenService,
            ILogger<AuthHandler> logger,
            IConfiguration configuration)
        {
            _mediator = mediator;
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
            _logger = logger;
            _configuration = configuration;
            _secretKey = _configuration.GetSection("SecretKey").Value;
        }
        public IMediator _mediator { get; }
        public IUserRepository _usuarioRepository { get; }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {           
            var passwordHash = Common.Util.ComputeSHA256(request.Password, _secretKey);
            var user = await _usuarioRepository.GetUserByUsernameOrEmailAndPassword(request.Username, passwordHash);
            if (user == null)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.IncorrectData,Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Unauthorized);
            if(!user.IsActive)
                throw new ExceptionCustom(Models.Enums.MessageCodesApi.UserIsInactive, Models.Enums.ResponseType.Error, System.Net.HttpStatusCode.Unauthorized);
            var token = _tokenService.GenerateTokenJwt(user);
            return new LoginResponse() { Token = token };
        }
    }
}
