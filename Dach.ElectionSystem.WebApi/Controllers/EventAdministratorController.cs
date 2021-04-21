
using System.Net.Cache;
using Dach.ElectionSystem.Models.Request.EventAdministrator;
using Dach.ElectionSystem.Models.Response.EventAdministrator;
using Dach.ElectionSystem.Models.ResponseBase;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Utils.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Dach.ElectionSystem.WebApi.Controllers
{
    [Route("api/EventAdministrators")]
    [ApiController]
    [ServiceFilter(typeof(ModelFilter))]
    public class EventAdministratorController : ApiControllerBase
    {
        #region Constructor
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public EventAdministratorController(IUserRepository userRepository, IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }
        #endregion

        #region Methods Controller
        /// <summary>
        /// Crear nuevo EventAdministratoro
        /// </summary>
        /// <param name="idEvent"></param>
        /// <param name="idUser"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{idEvent}/users/{idUser}")]
        [ProducesResponseType(200, Type = typeof(EventAdministratorCreateResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> CreateEventAdministrator(
            [FromRoute] int idEvent,
            [FromRoute] int idUser,
            [FromBody] EventAdministratorCreateRequest request)

        {
            request.IdEvent = idEvent;
            request.IdUser = idUser;
            return Success(await _mediator.Send(request));
        }

        /// <summary>
        /// Desactivar Administrador de Evento
        /// </summary>
        /// <param name="idEvent"></param>
        /// <param name="idUser"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{idEvent}/users/{idUser}")]
        [ProducesResponseType(200, Type = typeof(EventAdministratorDeleteResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> DesactiveEventAdministrator(
            [FromRoute] int idEvent,
            [FromRoute] int idUser,
            [FromBody] EventAdministratorDeleteRequest request)

        {
            request.IdEvent = idEvent;
            request.IdUser = idUser;
            return Success(await _mediator.Send(request));
        }

        /// <summary>
        /// Activar EventAdministratoro
        /// </summary>
        /// <param name="idEvent"></param>
        /// <param name="idUser"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{idEvent}/users/{idUser}")]
        [ProducesResponseType(200, Type = typeof(EventAdministratorUpdateResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> UpdateEventAdministrator(
            [FromRoute] int idEvent,
            [FromRoute] int idUser,
            [FromBody] EventAdministratorUpdateRequest request)

        {
            request.IdEvent = idEvent;
            request.IdUser = idUser;
            return Success(await _mediator.Send(request));
        }


       
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(EventAdministratorGetResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        [Route("{idEvent}/users/{idUser}")]
        [Route("")]
        public async Task<IActionResult> GetHandler(
            [FromRoute] int idEvent,
            [FromRoute] int idUser,
            [FromBody] EventAdministratorGetRequest request)

        {
            request.IdEvent = idEvent;
            request.IdUser = idUser;
            return Success(await _mediator.Send(request));
        }

        #endregion

    }
}
