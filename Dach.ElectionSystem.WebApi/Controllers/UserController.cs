using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Models.Response.User;
using Dach.ElectionSystem.Models.ResponseBase;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dach.ElectionSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ServiceFilter(typeof(Utils.Filters.ModelFilter))]
    [ApiController]
    public class UserController : ApiControllerBase
    {
        #region Constructor
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Methods Controller
        /// <summary>
        /// Generar token mediante credenciales
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(GenericResponse<UserCreateResponse>))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> CreateUser(UserCreateRequest requestLogin) => Success(await _mediator.Send(requestLogin));

        #endregion
    }
}
