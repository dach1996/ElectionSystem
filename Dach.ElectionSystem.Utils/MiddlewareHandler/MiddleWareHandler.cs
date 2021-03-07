using Common.WebApi.Middleware;
using Dach.ElectionSystem.Utils.Segurity.JWT;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dach.ElectionSystem.Utils.MiddlewareHandler
{
    public static class MiddleWareHandler
    {
        public static IApplicationBuilder SetCustomMiddleWare(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseMiddleware<JwtAuthenticationMiddlware>();
            return app;
        }
    }
}
