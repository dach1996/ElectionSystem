﻿using Dach.ElectionSystem.Services.TokenJWT;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Utils.Segurity.JWT
{
    public class JwtAuthenticationMiddlware
    {

        private readonly RequestDelegate _next;

        public JwtAuthenticationMiddlware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task Invoke(HttpContext context, ITokenService tokenService)
        {
            if (IsUrlAllow(context))
            {
                await _next.Invoke(context);
            }
            else
            {
                tokenService.ValidateToken(context);
                await _next.Invoke(context);
            }
        }
        private static bool IsUrlAllow(HttpContext request)
        {
            var baseUrl = $"/api";
            return
                request.Request.Path.StartsWithSegments("/swagger") ||
                request.Request.Path.StartsWithSegments(baseUrl + "/Auth")||
                (request.Request.Path==(baseUrl + "/users")&& request.Request.Method=="POST")||
                request.Request.Path.StartsWithSegments("/Images");
        }

    }
}
