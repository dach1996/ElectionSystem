using System.Threading.Tasks;
using Dach.ElectionSystem.Models.Request.Vote;
using Dach.ElectionSystem.Models.Response.Vote;
using Dach.ElectionSystem.Models.ResponseBase;
using Dach.ElectionSystem.Utils.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Dach.ElectionSystem.WebApi.Controllers
{
    [Route("api/votes")]
    [ApiController]
    [ServiceFilter(typeof(ModelFilterAttribute))]
    public class VoteController : ApiControllerBase
    {
        #region Constructor
        private readonly IMediator _mediator;
        public VoteController(IMediator mediator) =>
            _mediator = mediator;
        #endregion
        #region Methods Controllers

        /// <summary>
        /// Registrar Participante siendo Administrador
        /// </summary>
        /// <param name="request"></param>
        /// <param name="idEvent"></param>
        /// <param name="idUser"></param>
        ///  <returns></returns>

        [Route("events/{idEvent}/users/{idUser}")]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(VoteCreateResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> CreateVote(
            [FromBody] VoteCreateRequest request,
            [FromRoute] int idEvent,
            [FromRoute] int idUser
           )
        {
            request.IdUser = idUser;
            request.IdEvent = idEvent;
            return Success(await _mediator.Send(request));
        }

        /// <summary>
        /// Registrar Participantes por  correo electrónico siendo Administrador
        /// </summary>
        /// <param name="request"></param>
        /// <param name="idEvent"></param>
        ///  <returns></returns>

        [Route("events/{idEvent}/users")]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(VoteCreateEmailResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> CreateVoteEmail(
            [FromBody] VoteCreateEmailRequest request,
            [FromRoute] int idEvent
           )
        {
            request.IdEvent = idEvent;
            return Success(await _mediator.Send(request));
        }

        /// <summary>
        /// Autoregistrase en el evento siendo usuario
        /// </summary>
        /// <param name="request"></param>
        /// <param name="idEvent"></param>
        ///  <returns></returns>

        [Route("events/{idEvent}")]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(VoteAutoCreateResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> AutoCreateVote(
            [FromBody] VoteAutoCreateRequest request,
            [FromRoute] int idEvent
           )
        {
            request.IdEvent = idEvent;
            return Success(await _mediator.Send(request));
        }

        /// <summary>
        /// Desactivar Votante
        /// </summary>
        /// <param name="request"></param>
        /// <param name="idEvent"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("events/{idEvent}/users/{idUser}")]
        [ProducesResponseType(200, Type = typeof(VoteDeleteResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> DesactiveVote(
            [FromQuery] VoteDeleteRequest request,
            [FromRoute] int idEvent,
            [FromRoute] int idUser)
        {
            request.IdUser = idUser;
            request.IdEvent = idEvent;
            return Success(await _mediator.Send(request));
        }

        /// <summary>
        /// Votar
        /// </summary>
        /// <param name="request"></param>
        /// <param name="idEvent"></param>
        /// <param name="idCandidate"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("events/{idEvent}/candidates/{idCandidate}")]
        [ProducesResponseType(200, Type = typeof(VoteUpdateResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> UpdateVote(
            [FromBody] VoteUpdateRequest request,
            [FromRoute] int idEvent,
            [FromRoute] int idCandidate)
        {
            request.IdEvent = idEvent;
            request.IdCandidate = idCandidate;
            return Success(await _mediator.Send(request));
        }



        /// <summary>
        /// Consultar Participantes
        /// </summary>
        /// <param name="request"></param>
        /// <param name="idEvent"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(VoteGetResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        [Route("events/{idEvent}")]
        public async Task<IActionResult> GetHandler(
            [FromQuery] VoteGetRequest request,
            [FromRoute] int idEvent)
        {
            request.IdEvent = idEvent;
            return Success(await _mediator.Send(request));
        }

        #endregion

    }
}
