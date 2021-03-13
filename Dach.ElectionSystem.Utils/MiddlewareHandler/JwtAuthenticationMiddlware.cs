using Dach.ElectionSystem.Services.TokenJWT;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Utils.Segurity.JWT
{
    public class JwtAuthenticationMiddlware
    {

        private readonly RequestDelegate _next;

        public ITokenService _tokenService { get; }

        public JwtAuthenticationMiddlware(RequestDelegate next, ITokenService tokenService)
        {
            _next = next;
            _tokenService = tokenService;
        }
        
        public async Task Invoke(HttpContext context)
        {
            if (IsUrlAllow(context))
            {
                await _next.Invoke(context);
            }
            else
            {
                _tokenService.ValidateToken(context);
                await _next.Invoke(context);
            }
        }
        private bool IsUrlAllow(HttpContext request)
        {
            var baseUrl = $"/api";
            return
                request.Request.Path.StartsWithSegments("/swagger") ||
                request.Request.Path.StartsWithSegments(baseUrl + "/Auth");
        }

    }
}
