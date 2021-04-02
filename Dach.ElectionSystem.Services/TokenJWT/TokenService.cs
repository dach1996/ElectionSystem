
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
using Microsoft.Extensions.Logging;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Models.RequestBase;

namespace Dach.ElectionSystem.Services.TokenJWT
{
    public class TokenService : ITokenService
    {

        #region Contructor
        private readonly ILogger<TokenService> _logger;
        public IConfiguration _configuration { get; }
        private string secretKey { get; set; }
        private string expireTime { get; set; }

        private readonly IUserRepository _userRepository;
        public TokenService(IConfiguration configuraton, ILogger<TokenService> logger, IUserRepository userRepository)
        {
            _configuration = configuraton;
            _logger = logger;
            _userRepository = userRepository;
            secretKey = _configuration.GetSection("SecretKey").Value;
            expireTime = _configuration.GetValue<string>("ParamsJWT:JWT_EXPIRE_MINUTES");
        }
        #endregion

        public string GenerateTokenJwt(User user)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(secretKey));
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
                    expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                    signingCredentials: signingCredentials
                    );

                var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
                return jwtTokenString;
            }
            catch (Exception ex)
            {
             _logger.LogError(ex.Message);
                throw;
            }
        }

        public void ValidateToken(HttpContext context)
        {
            try { 
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                if (token == null)
                    throw new ExceptionCustom(MessageCodesApi.WithOutToken, ResponseType.Error, HttpStatusCode.Unauthorized);
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
             catch (ArgumentException ex)

            {
                _logger.LogError(ex.Message);
                throw new ExceptionCustom(MessageCodesApi.InvalidToken, ResponseType.Error, HttpStatusCode.Unauthorized);
            } catch (SecurityTokenValidationException ex){
                 _logger.LogError(ex.Message);
                throw new ExceptionCustom(MessageCodesApi.TokenExpired, ResponseType.Error, HttpStatusCode.Unauthorized);
            }
        }

        public TokenModel GetTokenModel(HttpContext context)
        {
            try
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                if (token == null)
                    throw new ExceptionCustom(MessageCodesApi.WithOutToken, ResponseType.Error, HttpStatusCode.Unauthorized);
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = tokenHandler.ReadJwtToken(token);
                var claims = jwtSecurityToken.Claims.ToList();
                var username = claims.Where(c => c.Type == nameof(Models.Enums.Claim.Name)).First().Value;
                var email = claims.Where(c => c.Type == nameof(Models.Enums.Claim.Email)).First().Value;
                var id = claims.Where(c => c.Type == nameof(Models.Enums.Claim.Id)).First().Value;
                var tokenModel = new TokenModel()
                {
                    Username = username,
                    Email = email,
                    Id = id
                };
                return tokenModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ExceptionCustom(MessageCodesApi.InvalidParceToken, ResponseType.Error, HttpStatusCode.Unauthorized);
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
