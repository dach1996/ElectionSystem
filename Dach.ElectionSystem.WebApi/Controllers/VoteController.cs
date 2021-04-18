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
    [ServiceFilter(typeof(ModelFilter))]
    public class VoteController : ApiControllerBase
    {
        #region Constructor
        private readonly IMediator _mediator;
        public VoteController(IMediator mediator) =>
            _mediator = mediator;
        #endregion
        #region Methods Controllers

        /// <summary>
        /// Registrar Voto
        /// </summary>
        /// <param name="request"></param>
        /// <param name="idEvent"></param>

        /// <returns></returns>

        [Route("events/{idEvent}")]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(VoteCreateResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> CreateVote(
            [FromBody] VoteCreateRequest request,
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
        [Route("events/{idEvent}")]
        [ProducesResponseType(200, Type = typeof(VoteDeleteResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> DesactiveVote(
            [FromQuery] VoteDeleteRequest request,
            [FromRoute] int idEvent)
        {
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
        /// Consultar Votos
        /// </summary>
        /// <param name="request"></param>
        /// <param name="idEvent"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(VoteGetResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        [Route("events/{idEvent}")]
        [Route("events")]
        [Route("users/{idUser}")]
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
