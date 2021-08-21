
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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Models.RequestBase;

namespace Dach.ElectionSystem.Services.TokenJWT
{
    public class TokenService : ITokenService
    {

        #region Contructor
        private readonly string _secretKey;
        private readonly string _expireTime;
        public TokenService(IConfiguration configuraton)
        {
            _secretKey = configuraton.GetSection("SecretKey").Value;
            _expireTime = configuraton.GetValue<string>("ParamsJWT:JWT_EXPIRE_MINUTES");
        }
        #endregion

        public string GenerateTokenJwt(User user)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(_secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // Crea claims
            var claimsIdentity = new System.Collections.Generic.List<System.Security.Claims.Claim>()
                {
                    new System.Security.Claims.Claim(Models.Enums.Claim.Name.ToString(), user.UserName??String.Empty),
                    new System.Security.Claims.Claim(Models.Enums.Claim.Email.ToString(), user.Email),
                    new System.Security.Claims.Claim(Models.Enums.Claim.Id.ToString(), user.Id.ToString()),
                };

            //Crear tokens
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(

                subject: new ClaimsIdentity(claimsIdentity),
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(_expireTime)),
                signingCredentials: signingCredentials
                );

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }

        public void ValidateToken(HttpContext context)
        {
            try
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                if (token == null)
                    throw new CustomException(MessageCodesApi.WithOutToken, ResponseType.Error, HttpStatusCode.Unauthorized);
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_secretKey);
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
            catch (ArgumentException)
            {
                throw new CustomException(MessageCodesApi.InvalidToken, ResponseType.Error, HttpStatusCode.Unauthorized);
            }
            catch (SecurityTokenValidationException)
            {
                throw new CustomException(MessageCodesApi.TokenExpired, ResponseType.Error, HttpStatusCode.Unauthorized);
            }
        }

        public TokenModel GetTokenModel(HttpContext context)
        {
            try
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                if (token == null)
                    throw new CustomException(MessageCodesApi.WithOutToken, ResponseType.Error, HttpStatusCode.Unauthorized);
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = tokenHandler.ReadJwtToken(token);
                var claims = jwtSecurityToken.Claims.ToList();
                var username = claims.FirstOrDefault(c => c.Type == nameof(Models.Enums.Claim.Name)).Value;
                var email = claims.FirstOrDefault(c => c.Type == nameof(Models.Enums.Claim.Email)).Value;
                var id = claims.FirstOrDefault(c => c.Type == nameof(Models.Enums.Claim.Id)).Value;
                var tokenModel = new TokenModel()
                {
                    Username = username,
                    Email = email,
                    Id = id
                };
                return tokenModel;
            }
            catch (Exception)
            {
                throw new CustomException(MessageCodesApi.InvalidParceToken, ResponseType.Error, HttpStatusCode.Unauthorized);
            }
        }

        private bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        => expires != null && DateTime.UtcNow < expires;

    }
}
