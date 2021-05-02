using Dach.ElectionSystem.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dach.ElectionSystem.Models.ResponseBase
{
    /// <summary>
    /// Clase de respuesta base ApiControllerBase
    /// </summary>
    public class ApiControllerBase : ControllerBase
    {
        /// <summary>
        /// En caso de peticiones exitosas
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected IActionResult Success<T>(T data)
        {
            return Ok(new GenericResponse<T>
            {

                Code = 200,
                ResponseType = nameof(ResponseType.Data),
                Message = "Operación realizada con Éxito",
                Content = data
            }); 
        }
        /// <summary>
        /// Respuestas no encontradas
        /// </summary>
        /// <returns></returns>
        protected new IActionResult NotFound()
        {
            return NotFound(new GenericResponse<string>
            {
                Code = 404,
                Message = "No encontrado"
            });
        }

        /// <summary>
        /// Respuesta con errores
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected ActionResult BadRequestWithData<T>(T data)
        {

            return BadRequest(new GenericResponse<T>
            {
                Code = 2,
                Message = "Error al realizar petición",
                Content = data
            });
        }

        /// <summary>
        /// Repuestas con errores internos
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected IActionResult Error(string message)
        {
            return BadRequest(new GenericResponse<string>
            {
                Code = 400,
                ResponseType = nameof(ResponseType.Error),
                Message = message,
                Content = null
            });
        }
    }
}
