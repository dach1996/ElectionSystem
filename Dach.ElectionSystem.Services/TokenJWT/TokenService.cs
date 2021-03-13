
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Net;
using Dach.ElectionSystem.Models.Enums;
using Dach.ElectionSystem.Models.ExceptionGeneric;
using Dach.ElectionSystem.Services.TokenJWT;
using Microsoft.Extensions.Configuration;

namespace Dach.ElectionSystem.Utils.Segurity.JWT
{
    public class TokenService : ITokenService
    {
        #region Contructor
        public IConfiguration _configuration { get; }
        private string secretKey { get; set; }
        private string expireTime { get; set; }
        public TokenService(IConfiguration configuraton)
        {
            _configuration = configuraton;
            secretKey = _configuration.GetValue<string>("ParamsJWT:JWT_SECRET_KEY");
            expireTime = _configuration.GetValue<string>("ParamsJWT:JWT_EXPIRE_MINUTES");
        }
        #endregion

        public string GenerateTokenJwt(string username)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(secretKey));
                var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

                // Crea claims
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) });

                //Crear tokens
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                    subject: claimsIdentity,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                    signingCredentials: signingCredentials);

                var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
                return jwtTokenString;
            }
            catch (Exception)
            {
                //Logger.WL("GenerateTokenJwt", ex.Message, LogLevel.Error);
                return String.Empty;
            }

        }

        public void ValidateToken(HttpContext context)
        {
            try
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                if (token == null)
                    throw new ExeptionCustom(MessageCodesApi.WithOutToken, ResponseType.Error, HttpStatusCode.Unauthorized);
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(secretKey);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = this.LifetimeValidator,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }, out SecurityToken validatedToken);
            }
            catch (ExeptionCustom)
            {
                throw;
            }
            catch (Exception)
            {
                throw new ExeptionCustom(MessageCodesApi.InvalidToken, ResponseType.Error, HttpStatusCode.Unauthorized);
            }
        }
        private bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }
    }
}
