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
        /// <param name="totalCandidates"></param>
        public CandidateGetResponse(List<CandidateResponseBase> listCandidate, int totalCandidates)
        {
            ListCandidate = listCandidate;
            TotalCandidates = totalCandidates;
        }

        /// <summary>
        /// Lista de Candidatos
        /// </summary>
        public List<CandidateResponseBase> ListCandidate { get; set; }

        /// <summary>
        /// Cantidad total de candidatos en el evento
        /// </summary>
        /// <value></value>
        public int TotalCandidates { get; set; }
    }
}
