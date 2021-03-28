using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Models.Response.User;
using Dach.ElectionSystem.Models.ResponseBase;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


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
        /// Crear Usuario
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(GenericResponse<UserCreateResponse>))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> CreateUser([FromBody]UserCreateRequest request) => Success(await _mediator.Send(request));

        /// <summary>
        /// Actualizar Usuario
        /// </summary>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(GenericResponse<UserUpdateResponse>))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> UpdateUser([FromBody]UserUpdateRequest request) => Success(await _mediator.Send(request));

        /// <summary>
        /// Desactivar Usuario
        /// </summary>
        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(GenericResponse<UserDeleteResponse>))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> DeleteHandler([FromQuery] UserDeleteRequest request) => Success(await _mediator.Send(request));

        /// <summary>
        /// Consultar Usuarios
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GenericResponse<UserGetResponse>))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> GetHandler([FromQuery] UserGetRequest request) => Success(await _mediator.Send(request));

        #endregion
    }
}
