﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Dach.ElectionSystem.Models.ResponseBase;
using Dach.ElectionSystem.Models.Enums;
using Dach.ElectionSystem.Utils.Extension;
using Dach.ElectionSystem.Models.ExceptionGeneric;

namespace Dach.ElectionSystem.Utils.MiddlewareHandler
{
    /// <summary>
    /// Clase manejadora de expeciones MiddleWare
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        #region Constructor

        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
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
            catch (CustomException customEx)
            {
                await HandleCustomExceptionAsync(httpContext, customEx);
                _logger.LogWarning(customEx, "CustomException: {@CustomMessage} ", customEx.MessageCodesApi.GetEnumMember());
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Internal Error {@Message}: ", exception.Message);
                await HandleExceptionAsync(httpContext, exception);
            }
        }

        /// <summary>
        /// Controlador Genérico 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="customEx"></param>
        /// <returns></returns>
        private static Task HandleCustomExceptionAsync(HttpContext context, CustomException customEx)
        {

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)customEx.CodeHttp;
            var response = new GenericResponse<string>
            {
                Code = (int)customEx.MessageCodesApi,
                ResponseType = customEx.ResponseType.ToString(),
                Message = $"{customEx.MessageCodesApi.GetEnumMember()} {customEx.MessageSpecific}"
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
                Message = exception.Message + exception.InnerException ?? String.Empty,
                Content = null
            };
            return context.Response.WriteAsync(response.ToString());
        }
        #endregion
    }
}