using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Models.Response.User;
using Dach.ElectionSystem.Models.ResponseBase;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Dach.ElectionSystem.WebApi.Controllers
{
    [Route("api/users")]
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
        /// Actualizar Usuario
        /// </summary>
        [HttpPut]
        [ProducesResponseType(200, Type = typeof(GenericResponse<UserUpdateResponse>))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        [ServiceFilter(typeof(Utils.Filters.ModelFilterAttribute))]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateRequest request) => Success(await _mediator.Send(request));

        /// <summary>
        /// Consultar Usuarios por Id
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GenericResponse<UserGetResponse>))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        [Route("{id}")]
        [ServiceFilter(typeof(Utils.Filters.ModelFilterAttribute))]
        public async Task<IActionResult> GetByIdHandler([FromQuery] UserGetRequest request, [FromRoute] int? id)
        {
            if (id != null)
                request.Id = id;
            return Success(await _mediator.Send(request));
        }

        /// <summary>
        /// Consultar Usuarios
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(GenericResponse<UserGetResponse>))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        [ServiceFilter(typeof(Utils.Filters.ModelFilterAttribute))]
        public async Task<IActionResult> GetHandler([FromQuery] UserGetRequest request)
        => Success(await _mediator.Send(request));


        /// <summary>
        /// Crear Usuario
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(GenericResponse<UserCreateResponse>))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateRequest request)
        => Success(await _mediator.Send(request));


        /// <summary>
        /// Cambiar Contraseña
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(GenericResponse<Unit>))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        [ServiceFilter(typeof(Utils.Filters.ModelFilterAttribute))]
        [Route("changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        => Success(await _mediator.Send(request));

        /// <summary>
        /// Incrementar el número de eventos permitidos
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(GenericResponse<Unit>))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        [ServiceFilter(typeof(Utils.Filters.ModelFilterAttribute))]
        [Route("increaseEvents")]
        public async Task<IActionResult> IncreaseEvents([FromBody] IncreaseEventsRequest request)
        => Success(await _mediator.Send(request));

        #endregion
    }
}
