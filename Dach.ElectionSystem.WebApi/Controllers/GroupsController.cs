using Dach.ElectionSystem.Models.Request.Group;
using Dach.ElectionSystem.Models.Response.Group;
using Dach.ElectionSystem.Models.ResponseBase;
using Dach.ElectionSystem.Utils.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace Dach.ElectionSystem.WebApi.Controllers
{
    [Route("api/groups")]
    [ApiController]
    [ServiceFilter(typeof(ModelFilter))]
    public class GroupsController : ApiControllerBase
    {

        #region Constructor
        private readonly IMediator _mediator;
        public GroupsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        /// <summary>
        /// Crear nuevo Groupo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(GroupCreateResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> CreateGroup([FromBody] GroupCreateRequest request) => Success(await _mediator.Send(request));


        /// <summary>
        /// Desactivar Groupo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(200, Type = typeof(GroupDeleteResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> DesactiveGroup([FromRoute] GroupDeleteRequest request) => Success(await _mediator.Send(request));

        /// <summary>
        /// Actualizar Groupo
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(200, Type = typeof(GroupUpdateResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> UpdateGroup([FromBody] GroupUpdateRequest request, [FromRoute] int? id)
        {
            request.Id = id;
            return Success(await _mediator.Send(request));
        }



        /// <summary>
        /// Consulta de Groupos
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GroupGetResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        [Route("{id}")]
        [Route("")]
        public async Task<IActionResult> GetHandler([FromQuery] GroupGetRequest request, [FromRoute] int? id)
        {
            request.Id = id;
            return
            Success(await _mediator.Send(request));
        }

    }
}
