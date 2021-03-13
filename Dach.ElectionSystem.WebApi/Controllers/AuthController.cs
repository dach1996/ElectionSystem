using Dach.ElectionSystem.Models.Auth;
using Dach.ElectionSystem.Models.ResponseBase;
using Dach.ElectionSystem.Services.Logger;
using Dach.ElectionSystem.Utils.Log;
using Dach.ElectionSystem.Utils.Segurity.JWT;
using log4net.Core;
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
        private readonly IConfiguration _configuration;
        private readonly ILoggerCustom _logger;
        private readonly TokenHandler _tokenHandler;

        public AuthController(IConfiguration configuration, ILoggerCustom logger
          )
        {
            _configuration = configuration;
            _logger = logger;
        }

        /// <summary>
        /// Generar token mediante credenciales
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> Post(RequestLogin requestLogin)
        {
            return await Task<IActionResult>.Run(() =>
            {
                try
                {
                    var secretKey = _configuration.GetValue<string>("ParamsJWT:JWT_SECRET_KEY");
                    var expireTime = _configuration.GetValue<string>("ParamsJWT:JWT_EXPIRE_MINUTES");
                    var token = new TokenHandler().GenerateTokenJwt(requestLogin.Username, secretKey, expireTime);
                    return Success(token);
                }
                catch (Exception ex)
                {
                    return Error(ex.Message);
                }
            });
        }

    }
}
