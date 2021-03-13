using Dach.ElectionSystem.Models.Auth;
using Dach.ElectionSystem.Models.Response.Auth;
using Dach.ElectionSystem.Models.ResponseBase;
using Dach.ElectionSystem.Services.Logger;
using Dach.ElectionSystem.Utils.Log;
using Dach.ElectionSystem.Utils.Segurity.JWT;
using log4net.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.WebApi.Properties
{
    /// <summary>
    /// Controlador Autorizador mediante Token JWT
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiControllerBase
    {
        private readonly ILoggerCustom _logger;
        private readonly IMediator _mediator;
        public AuthController(ILoggerCustom logger, IMediator mediator
          )
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Generar token mediante credenciales
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(LoginResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> Auth(LoginRequest requestLogin) => Success(await _mediator.Send(requestLogin));

    }
}
