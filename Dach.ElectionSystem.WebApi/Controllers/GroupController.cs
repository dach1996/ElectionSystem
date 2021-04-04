using Dach.ElectionSystem.Models.Request.Group;
using Dach.ElectionSystem.Models.Response.Group;
using Dach.ElectionSystem.Models.ResponseBase;
using Dach.ElectionSystem.Utils.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace Dach.ElectionSystem.WebApi.Controllers
{
    [Route("api/events")]
    [ApiController]
    [ServiceFilter(typeof(ModelFilter))]
    public class GroupController : ApiControllerBase
    {

        #region Constructor
        private readonly IMediator _mediator;
        public GroupController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Methods Controllers

        /// <summary>
        /// Crear nuevo evento
        /// </summary>
        /// <param name="request"></param>
        /// <param name="idEvent"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{idEvent}/groups")]
        [ProducesResponseType(200, Type = typeof(GroupCreateResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> CreateGroup([FromBody] GroupCreateRequest request, int idEvent)
        {
            request.IdEvent = idEvent;
            return Success(await _mediator.Send(request));
        }


        /// <summary>
        /// Desactivar Grupo
        /// </summary>
        /// <param name="request"></param>
        /// <param name="idEvent"></param>
        /// <param name="idGroup"></param>
        [HttpDelete]
        [Route("{idEvent}/groups/{idGroup}")]
        [ProducesResponseType(200, Type = typeof(GroupDeleteResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> DesactiveGroup([FromRoute] GroupDeleteRequest request, [FromRoute] int idEvent, [FromRoute] int idGroup)
        {
            request.IdEvent = idEvent;
            request.IdGroup = idGroup;
            return Success(await _mediator.Send(request));
        }

        /// <summary>
        /// Actualizar Groupo
        /// </summary>
        /// <param name="request"></param>
        /// <param name="idEvent"></param>
        /// <param name="idGroup"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{idEvent}/groups/{idGroup}")]
        [ProducesResponseType(200, Type = typeof(GroupUpdateResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> UpdateGroup([FromBody] GroupUpdateRequest request, [FromRoute] int idEvent, [FromRoute] int idGroup)
        {
            request.IdGroup = idGroup;
            request.IdEvent = idEvent;
            return Success(await _mediator.Send(request));
        }

        /// <summary>
        /// Consulta de Groupos
        /// </summary>
        /// <param name="request"></param>
        /// <param name="idEvent"></param>
        /// <param name="idGroup"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GroupGetResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        [Route("{idEvent}/groups/{idGroup}")]
        [Route("{idEvent}/groups")]
        [Route("groups")]
        public async Task<IActionResult> GetHandler([FromQuery] GroupGetRequest request, [FromRoute] int? idEvent, [FromRoute] int? idGroup)
        {
            request.IdEvent = idEvent;
            request.IdGroup = idGroup;
            return Success(await _mediator.Send(request));
        }
        #endregion

    }
}
