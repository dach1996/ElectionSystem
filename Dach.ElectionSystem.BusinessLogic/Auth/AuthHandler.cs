using Dach.ElectionSystem.Models.Auth;
using Dach.ElectionSystem.Models.Response.Auth;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Services.TokenJWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.BusinessLogic.Auth
{
    public class AuthHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly ITokenService _tokenService;

        public AuthHandler(IMediator mediator, IUsuarioRepository usuarioRepository, ITokenService tokenService)
        {
            _mediator = mediator;
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }
        public IMediator _mediator { get; }
        public IUsuarioRepository _usuarioRepository { get; }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = (await _usuarioRepository.GetAsync()).ToList().First();
            var token = _tokenService.GenerateTokenJwt(user.UserName);
            return new LoginResponse() { Token = token };
        }
    }
}
