using System.Text.Json.Serialization;
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
        [JsonIgnore]
        public int IdEvent { get; set; }

        /// <summary>
        /// Id de Candidato
        /// </summary>
        /// <value></value>
         [JsonIgnore]
        public int IdCandidate { get; set; }     
        
    }
}
