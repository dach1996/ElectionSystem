using Dach.ElectionSystem.Models.Request.Candidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Models.Response.Candidate
{
    public class CandidateCreateResponse : CandidateCreateRequest
    {
        public int Id { get; set; }
    }
}
