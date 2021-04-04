using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Response.Candidate;
using Dach.ElectionSystem.Models.ResponseBase;
using Dach.ElectionSystem.Services.Logger;
using Dach.ElectionSystem.Utils.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ModelFilter))]
    public class CandidateController : ApiControllerBase
    {
        /*
                private readonly IMediator _mediator;
                public CandidateController(IMediator mediator
                  )
                {
                    _mediator = mediator;
                }

                /// <summary>
                /// Crear Candidato
                /// </summary>
                /// <param name="candidateCreateRequest"></param>
                /// <returns></returns>
                [HttpPost]
                [ProducesResponseType(200, Type = typeof(CandidateCreateResponse))]
                [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
                [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
                public async Task<IActionResult> CreateCandidate([FromBody]CandidateCreateRequest candidateCreateRequest) 
                    => Success(await _mediator.Send(candidateCreateRequest));

                /// <summary>
                /// Obtener datos de Candidato
                /// </summary>
                /// <param name="candidateCreateRequest"></param>
                /// <returns></returns>
                [HttpGet]
                [ProducesResponseType(200, Type = typeof(CandidateCreateResponse))]
                [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
                [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
                public async Task<IActionResult> GetCandidate([FromQuery] CandidateCreateRequest candidateCreateRequest)
                    => Success(await _mediator.Send(candidateCreateRequest));

                /// <summary>
                /// Modificar Candidato
                /// </summary>
                /// <param name="candidateCreateRequest"></param>
                /// <returns></returns>
                [HttpPut]
                [ProducesResponseType(200, Type = typeof(CandidateCreateResponse))]
                [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
                [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
                public async Task<IActionResult> PutCandidate([FromBody] CandidateCreateRequest candidateCreateRequest)
                   => Success(await _mediator.Send(candidateCreateRequest));

                /// <summary>
                /// Borrar Candidato
                /// </summary>
                /// <param name="candidateCreateRequest"></param>
                /// <returns></returns>
                [HttpDelete]
                [ProducesResponseType(200, Type = typeof(CandidateCreateResponse))]
                [ProducesResponseType(400, Type = typeof(GenericResponse<string>))]
                [ProducesResponseType(401, Type = typeof(GenericResponse<string>))]
                public async Task<IActionResult> DeleteCandidate([FromBody] CandidateCreateRequest candidateCreateRequest)
                   => Success(await _mediator.Send(candidateCreateRequest));


        */
    }
}
