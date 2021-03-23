using Dach.ElectionSystem.Models.Response.Candidate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Models.Request.Candidate
{
    public class CandidateGetRequest : IRequest<CandidateGetResponse>
    {
    }
}
