using Dach.ElectionSystem.Models.Auth;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Linq;
using Dach.ElectionSystem.Utils.ExceptionGeneric;
using System.Net;
using Dach.ElectionSystem.Models.Enums;

namespace Dach.ElectionSystem.Utils.Segurity.JWT
{
    public class TokenHandler
    {
        public string GenerateTokenJwt(string username, string key, string minutsToExpired)
        {
            try
            {

                var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(key));
                var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

                // Crea claims
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) });

                //Crear tokens
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                    subject: claimsIdentity,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(minutsToExpired)),
                    signingCredentials: signingCredentials);

                var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
                return jwtTokenString;
            }
            catch (Exception ex)
            {
                //Logger.WL("GenerateTokenJwt", ex.Message, LogLevel.Error);
                return String.Empty;
            }

        }

        public void ValidateToken(HttpContext context, string secretKey)
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
