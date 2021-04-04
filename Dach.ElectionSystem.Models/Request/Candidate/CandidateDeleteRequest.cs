using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Models.Response.Candidate;
using MediatR;

namespace Dach.ElectionSystem.Models.Request.Candidate
{
    /// <summary>
    /// Clase CandidateDeleteRequest
    /// </summary>
    public class CandidateDeleteRequest : RequestBaseImpl, IRequest<CandidateDeleteResponse>
    {
        /// <summary>
        /// Id de Evento
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public int? IdEvent { get; set; }

        /// <summary>
        /// Id de Grupo
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public int? IdGroup { get; set; }

        /// <summary>
        /// Id de Candidato
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public int? IdCandidate { get; set; }
    }
}
