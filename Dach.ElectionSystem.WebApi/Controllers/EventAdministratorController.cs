
using System.Net.Cache;
using Dach.ElectionSystem.Models.Request.EventAdministrator;
using Dach.ElectionSystem.Models.Response.EventAdministrator;
using Dach.ElectionSystem.Models.ResponseBase;
using Dach.ElectionSystem.Utils.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Dach.ElectionSystem.WebApi.Controllers
{
    [Route("api/EventAdministrators")]
    [ApiController]
    [ServiceFilter(typeof(ModelFilterAttribute))]
    public class EventAdministratorController : ApiControllerBase
    {
        #region Constructor
        private readonly IMediator _mediator;
        public EventAdministratorController(IMediator mediator)
        {
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
        /// Activar / Desactivar Administrador de Evento
        /// </summary>
        /// <param name="idEvent"></param>
        /// <param name="idUser"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{idEvent}/users/{idUser}")]
        [ProducesResponseType(200, Type = typeof(EventAdministratorDesactiveResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> DesactiveEventAdministrator(
            [FromRoute] int idEvent,
            [FromRoute] int idUser,
            [FromQuery] EventAdministratorDesactiveRequest request)

        {
            request.IdEvent = idEvent;
            request.IdUser = idUser;
            return Success(await _mediator.Send(request));
        }

        
       /// <summary>
       /// Consulta lista de administradores por evento
       /// </summary>
       /// <param name="idEvent"></param>
       /// <param name="request"></param>
       /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(EventAdministratorGetResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        [Route("{idEvent}")]
        public async Task<IActionResult> GetHandler(
            [FromRoute] int idEvent,
            [FromQuery] EventAdministratorGetRequest request)

        {
            request.IdEvent = idEvent;
            return Success(await _mediator.Send(request));
        }

        #endregion

    }
}
