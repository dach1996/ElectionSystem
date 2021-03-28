using Dach.ElectionSystem.Models.Request.Candidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Models.Response.Candidate
{
    /// <summary>
    /// Clase CandidateCreateResponse
    /// </summary>
    public class CandidateCreateResponse : CandidateCreateRequest
    {
        /// <summary>
        /// Id de candidato
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
    }
}
