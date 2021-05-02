using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Response.Candidate;
using Dach.ElectionSystem.Models.ResponseBase;
using Dach.ElectionSystem.Utils.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.WebApi.Controllers
{
    [Route("api/events/{idEvent}/candidates")]
    [ApiController]
    [ServiceFilter(typeof(ModelFilterAttribute))]
    public class CandidateController : ApiControllerBase
    {
        #region Constructor
        private readonly IMediator _mediator;
        public CandidateController(IMediator mediator) =>
            _mediator = mediator;
        #endregion
        #region Methods Controllers

       /// <summary>
       /// Crear Candidato
       /// </summary>
       /// <param name="request"></param>
       /// <param name="idEvent"></param>
       /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CandidateCreateResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> CreateCandidate(
            [FromBody] CandidateCreateRequest request,
            [FromRoute] int idEvent )
        {
            request.IdEvent = idEvent;
            return Success(await _mediator.Send(request));
        }

        /// <summary>
        /// Desactivar Candidato
        /// </summary>
        /// <param name="request"></param>
        /// <param name="idEvent"></param>
        /// <param name="idCandidate"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{idCandidate}")]
        [ProducesResponseType(200, Type = typeof(CandidateDeleteResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> DesactiveCandidate(
            [FromQuery] CandidateDeleteRequest request,
            [FromRoute] int? idEvent,
            [FromRoute] int? idCandidate)
        {
            request.IdEvent = idEvent;
            request.IdCandidate = idCandidate;
            return Success(await _mediator.Send(request));
        }

        /// <summary>
        /// Actualizar Candidato
        /// </summary>
        /// <param name="request"></param>
        /// <param name="idEvent"></param>
        /// <param name="idCandidate"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{idCandidate}")]
        [ProducesResponseType(200, Type = typeof(CandidateUpdateResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        public async Task<IActionResult> UpdateCandidate(
            [FromBody] CandidateUpdateRequest request,
            [FromRoute] int idEvent,
            [FromRoute] int idCandidate)
        {
            request.IdCandidate = idCandidate;
            request.IdEvent = idEvent;
            return Success(await _mediator.Send(request));
        }


        /// <summary>
        /// Consultar Candidato
        /// </summary>
        /// <param name="request"></param>
        /// <param name="idEvent"></param>
        /// <param name="idCandidate"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(CandidateGetResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        [Route("{idCandidate}")]
        [Route("")]
        public async Task<IActionResult> GetHandler(
         [FromQuery] CandidateGetRequest request,
         [FromRoute] int? idEvent,
         [FromRoute] int? idCandidate)
        {
            request.IdEvent = idEvent;
            request.IdCandidate = idCandidate;
            return Success(await _mediator.Send(request));
        }
        #endregion
    }
}
