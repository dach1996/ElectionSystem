using System.Collections.Generic;
namespace Dach.ElectionSystem.Models.Response.Candidate
{
    /// <summary>
    /// Clase CandidateGetResponse
    /// </summary>
    public class CandidateGetResponse
    {
        /// <summary>
        /// Lista de Candidatos
        /// </summary>
        public List<CandidateResponseBase>  ListCandidate{ get; set; }
    }
}
