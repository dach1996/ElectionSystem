using System;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Xml;
using System.ServiceModel;
using Dach.ElectionSystem.Models.ResponseBase;
using Dach.ElectionSystem.Models.Enums;
using Microsoft.AspNetCore.Builder;

namespace Common.WebApi.Middleware
{
    /// <summary>
    /// Exception manager
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware( RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext).ConfigureAwait(false);
            }
            catch (Exception customEx)
            {
                 await HandleExceptionAsync(httpContext,"Errors"+customEx.Message);
            }
        }

       private static Task HandleExceptionAsync(HttpContext context, string message, string source = null)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.OK;

            var response = new GenericResponse<string>
            {
                Code = 200,
                ResponseType = nameof(ResponseType.Error),
                Message = message
            };
            return context.Response.WriteAsync(response.ToString());
        }
    }
    public static class ExceptionMiddlware
    {
        public static IApplicationBuilder ExeptionMiddlware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            return app;
        }
    }
}