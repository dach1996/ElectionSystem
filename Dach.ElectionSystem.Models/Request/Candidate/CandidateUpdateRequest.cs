using Dach.ElectionSystem.Models.Response.Candidate;
using MediatR;

namespace Dach.ElectionSystem.Models.Request.Candidate
{
    /// <summary>
    /// Clase CandidatePutRequest
    /// </summary>
    public class CandidateUpdateRequest : CandidateBaseRequest, IRequest<CandidateUpdateResponse>
    {
        /// <summary>
        /// Id de Evento
        /// </summary>
        /// <value></value>
        public int IdEvent { get; set; }

        /// <summary>
        /// Id de Grupo
        /// </summary>
        /// <value></value>
        public int IdGroup { get; set; }

        /// <summary>
        /// Id de Candidato
        /// </summary>
        /// <value></value>
        public int IdCandidate { get; set; }
    }
}
