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
            [FromRoute] int idEvent)
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
            [FromRoute] int idEvent,
            [FromRoute] int idCandidate)
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
        /// Subir Imagen
        /// </summary>
        /// <param name="request"></param>
        /// <param name="idEvent"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("image")]
        [ProducesResponseType(200, Type = typeof(GenericResponse<Unit>))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<Unit>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<Unit>))]
        public async Task<IActionResult> UploadImagen(
            [FromForm] CandidateImageRequest request,
            [FromRoute] int idEvent
           )
        {
            request.IdEvent = idEvent;
            return Success(await _mediator.Send(request));
        }

        /// <summary>
        /// Borrar Imagen
        /// </summary>
        /// <param name="request"></param>
        /// <param name="idEvent"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("image")]
        [ProducesResponseType(200, Type = typeof(GenericResponse<Unit>))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<Unit>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<Unit>))]
        public async Task<IActionResult> DeleteImage(
            [FromQuery] CandidateImageDeleteRequest request,
            [FromRoute] int idEvent
           )
        {
            request.IdEvent = idEvent;
            return Success(await _mediator.Send(request));
        }


        /// <summary>
        /// Consultar candidato de evento por Id
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
        public async Task<IActionResult> GetByIdHandler(
         [FromQuery] CandidateGetRequest request,
         [FromRoute] int idEvent,
         [FromRoute] int? idCandidate)
        {
            request.IdEvent = idEvent;
            request.IdCandidate = idCandidate;
            return Success(await _mediator.Send(request));
        }

        
        /// <summary>
        /// Consultar Candidatos de evento
        /// </summary>
        /// <param name="request"></param>
        /// <param name="idEvent"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(CandidateGetResponse))]
        [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
        [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
        [Route("")]
        public async Task<IActionResult> GetByEventHandler(
         [FromQuery] CandidateGetRequest request,
         [FromRoute] int idEvent)
        {
            request.IdEvent = idEvent;
            return Success(await _mediator.Send(request));
        }
        #endregion
    }
}
