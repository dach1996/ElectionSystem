using Dach.ElectionSystem.Models.Auth;
using Dach.ElectionSystem.Models.Response.Auth;
using Dach.ElectionSystem.Models.ResponseBase;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.WebApi.Properties
{
    /// <summary>
    /// Controlador Autorizador mediante Token JWT
    /// </summary>
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ApiControllerBase
    {
        #region Constructor
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Methods Controller
        /// <summary>
        /// Generar token mediante credenciales
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(GenericResponse<LoginResponse>))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        [Route("login")]
        public async Task<IActionResult> Auth(LoginRequest requestLogin)
         => Success(await _mediator.Send(requestLogin));

         /// <summary>
        /// Olvidé contraseña
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(GenericResponse<Unit>))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        [Route("forgottenpassword")]
        public async Task<IActionResult> ForgottenPassword(ForggotenPasswordRequest requestLogin)
         => Success(await _mediator.Send(requestLogin));
        #endregion

    }
}
