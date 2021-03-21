using Catel.Data;
using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.ResponseBase;
using Dach.ElectionSystem.Services.Logger;
using Dach.ElectionSystem.Utils.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dach.ElectionSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ModelFilter))]
    public class CandidateController : ApiControllerBase
    {
        private readonly ILoggerCustom _logger;
        private readonly IMediator _mediator;
        public CandidateController(ILoggerCustom logger, IMediator mediator
          )
        {
            _logger = logger;
            _mediator = mediator;
        }
        // GET: api/<CandidateController>
        [HttpPost]
        public async Task<IActionResult> CreateCandidate([FromBody]CandidateCreateRequest candidateCreateRequest) 
            => Success(await _mediator.Send(candidateCreateRequest));
 

      
    }
}
