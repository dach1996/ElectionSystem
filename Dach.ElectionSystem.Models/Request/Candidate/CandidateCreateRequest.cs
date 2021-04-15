using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.Response.Candidate;
using MediatR;
namespace Dach.ElectionSystem.Models.Request.Candidate
{
    /// <summary>
    /// Clase Candidate Create Request
    /// </summary>
    public class CandidateCreateRequest : CandidateBaseRequest, IRequest<CandidateCreateResponse>
    {
        /// <summary>
        /// Id de Evento
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public int IdEvent { get; set; }

        /// <summary>
        /// Id de Grupo
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public int IdGroup { get; set; }

        /// <summary>
        /// Id de Usuario a Candidato
        /// </summary>
        /// <value></value>
        public int IdUser { get; set; }
    }
}
