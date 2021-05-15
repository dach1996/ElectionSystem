using System.Collections.Generic;
namespace Dach.ElectionSystem.Models.Response.Candidate
{
    /// <summary>
    /// Clase CandidateGetResponse
    /// </summary>
    public class CandidateGetResponse
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="listCandidate"></param>
        public CandidateGetResponse(List<CandidateResponseBase> listCandidate)
        {
            ListCandidate = listCandidate;
        }

        /// <summary>
        /// Lista de Candidatos
        /// </summary>
        public List<CandidateResponseBase>  ListCandidate{ get; set; }
    }
}
