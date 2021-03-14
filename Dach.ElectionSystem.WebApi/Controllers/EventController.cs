using Dach.ElectionSystem.Models.Auth;
using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Models.Response.Event;
using Dach.ElectionSystem.Models.ResponseBase;
using Dach.ElectionSystem.Repository.DBContext;
using Dach.ElectionSystem.Repository.Interfaces;
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
    [ApiController]
    public class EventController : ApiControllerBase
    {
        #region Constructor
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;
        public EventController(IUserRepository userRepository, IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }
        #endregion

        #region Request
        /// <summary>
        /// Crear nuevo evento
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(EventCreateResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> Post([FromBody] EventCreateRequest request) => Success(await _mediator.Send(request));

        /// <summary>
        /// Eliminar Evento
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(EventDeleteResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> Delete([FromQuery] EventDeleteRequest request) => Success(await _mediator.Send(request));
        #endregion

    }
}
