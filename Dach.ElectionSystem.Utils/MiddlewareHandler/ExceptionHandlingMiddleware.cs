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
using Dach.ElectionSystem.Utils.ExceptionGeneric;
using Dach.ElectionSystem.Utils.Extension;

namespace Common.WebApi.Middleware
{
    /// <summary>
    /// Clase manejadora de expeciones MiddleWare
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        #region Constructor

        private readonly RequestDelegate _next;
        /// <summary>
        /// Constructor
        /// </summary>
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        #endregion

        #region Metodos
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
            catch (ExeptionCustom customEx)
            {
                await HandleExceptionCustomAsync(httpContext, customEx);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(httpContext, exception);
            }
        }

        /// <summary>
        /// Controlador Genérico 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="customEx"></param>
        /// <returns></returns>
        private static Task HandleExceptionCustomAsync(HttpContext context, ExeptionCustom customEx)
        {

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)customEx.CodeHttp;
            var response = new GenericResponse<string>
            {
                Code = (int)customEx.MessageCodesApi,
                ResponseType = customEx.ResponseType.ToString(),
                Message = customEx.MessageCodesApi.GetEnumMember()
            };
            return context.Response.WriteAsync(response.ToString());
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            var response = new GenericResponse<string>
            {
                Code = (int)MessageCodesApi.ErrorGeneric,
                ResponseType = ResponseType.Error.ToString(),
                Message = exception.Message,
                Content = null
            };
            return context.Response.WriteAsync(response.ToString());
        }
        #endregion
    }
}