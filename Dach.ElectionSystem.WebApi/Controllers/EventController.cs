
using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Models.Response.Event;
using Dach.ElectionSystem.Models.ResponseBase;
using Dach.ElectionSystem.Utils.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Dach.ElectionSystem.WebApi.Controllers
{
    [Route("api/events")]
    [ApiController]
    [ServiceFilter(typeof(ModelFilterAttribute))]
    public class EventController : ApiControllerBase
    {
        #region Constructor
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Methods Controller
        /// <summary>
        /// Crear nuevo evento
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(EventCreateResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> CreateEvent([FromBody] EventCreateRequest request) => Success(await _mediator.Send(request));


        /// <summary>
        /// Desactivar Evento
        /// </summary>
        /// <param name="request"></param>
        /// <param name="idEvent"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{idEvent}")]
        [ProducesResponseType(200, Type = typeof(EventDeleteResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> DesactiveEvent([FromBody] EventDeleteRequest request, [FromRoute] int idEvent)
        {
            request.IdEvent = idEvent;
            return Success(await _mediator.Send(request));
        }

        /// <summary>
        /// Actualizar Evento
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(200, Type = typeof(EventUpdateResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> UpdateEvent([FromBody] EventUpdateRequest request, [FromRoute] int? id)
        {
            request.Id = id;
            return Success(await _mediator.Send(request));
        }



        /// <summary>
        /// Consulta de Eventos
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(EventGetResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        [Route("")]
        public async Task<IActionResult> GetHandler(
            [FromQuery] EventGetRequest request)
             => Success(await _mediator.Send(request));


        /// <summary>
        /// Consulta de Evento
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(EventGetResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdHandler(
            [FromQuery] EventGetRequest request,
            [FromRoute] int? id)
        {
            request.Id = id;
            return Success(await _mediator.Send(request));
        }

        /// <summary>
        /// Verificar Enrolamiento con el evento
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("verifyRelationship")]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(EventHasRoledWithEventResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> HasRoledWithEvent(
           [FromBody] EventHasRoledWithEventRequest request
        )
        => Success(await _mediator.Send(request));


        /// <summary>
        /// Consulta de resultados
        /// </summary>
        /// <param name="request"></param>
        /// <param name="idEvent"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(EventGetResultResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        [Route("{idEvent}/results")]
        public async Task<IActionResult> GetResultEvent(
            [FromQuery] EventGetResultRequest request,
            [FromRoute] int idEvent)
        {
            request.IdEvent = idEvent;
            return Success(await _mediator.Send(request));
        }

        /// <summary>
        /// Guardar Imágen del evento
        /// </summary>
        /// <param name="request"></param>
        /// <param name="idEvent"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Unit))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        [Route("{idEvent}/image")]
        public async Task<IActionResult> UpdateImage(
            [FromForm] EventImageRequest request,
            [FromRoute] int idEvent
         )
        {
            request.IdEvent = idEvent;
            return Success(await _mediator.Send(request));
        }
    }

    #endregion
}
