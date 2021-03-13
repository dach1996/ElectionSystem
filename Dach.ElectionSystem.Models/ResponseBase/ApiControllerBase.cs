using Dach.ElectionSystem.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dach.ElectionSystem.Models.ResponseBase
{
    public class ApiControllerBase : ControllerBase
    {
        
        protected  IActionResult Success<T>(T data)
        {
            return Ok(new GenericResponse<T>
            {

                Code = 200,
                ResponseType = nameof(ResponseType.Data),
                Message = "Operación realizada con Éxito",
                Content = data
            });;
        }
        protected new IActionResult NotFound()
        {
            return NotFound(new GenericResponse<string>
            {
                Code = 404,
                Message ="No encontrado"
            });
        }

        protected ActionResult BadRequestWithData<T>(T data)
        {
           
            return BadRequest(new GenericResponse<T>
            {
                Code = 2,
                Message ="Error al realizar petición",
                Content = data
            });
        }

        protected  IActionResult Error(string message)
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
