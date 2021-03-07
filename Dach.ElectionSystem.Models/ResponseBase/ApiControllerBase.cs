using Dach.ElectionSystem.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dach.ElectionSystem.Models.ResponseBase
{
    public class ApiControllerBase : ControllerBase
    {
        
        protected IActionResult Success<T>(T data)
        {

            return Ok(new GenericResponse<T>
            {
                Code = 200,
                ResponseType = nameof(ResponseType.Data),
                Message ="ok",
                Content = data
            });
        }

        protected new IActionResult NotFound()
        {
            var message = (int)MessageCodesApi.SystemError;
            return Ok(new GenericResponse<string>
            {
                Code = 3,
                Message ="No encontrado"
            });
        }

        protected ActionResult BadRequestWithData<T>(T data)
        {
           
            return BadRequest(new GenericResponse<T>
            {
                Code = 2,
                Message ="errors",
                Content = data
            });
        }

        protected IActionResult Error(string message)
        {
           return BadRequest(new GenericResponse<string>
            {
                Code = 1,
                Message = "Errror",
                Content = message
            });
        }
    }
}
