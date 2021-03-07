using Dach.ElectionSystem.Models.Auth;
using Dach.ElectionSystem.Models.ResponseBase;
using Dach.ElectionSystem.Utils.Segurity.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Generar token mediante credenciales
        /// </summary>

        [HttpPost]
        public async Task<IActionResult> Post(RequestLogin requestLogin)
        {
            try
            {
                var secretKey = _configuration.GetValue<string>("ParamsJWT:JWT_SECRET_KEY");
                var expireTime = _configuration.GetValue<string>("ParamsJWT:JWT_EXPIRE_MINUTES");
                var token = new TokenHandler().GenerateTokenJwt(requestLogin.Username,secretKey,expireTime);
                return Success(token);
            }
            catch (Exception)
            {
                return Success<string>(await Task.Run(() => { return "HOLA"; }));
            }
        }

    }
}
