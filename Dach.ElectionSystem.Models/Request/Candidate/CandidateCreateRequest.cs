using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Models.Response.Candidate;
using MediatR;
namespace Dach.ElectionSystem.Models.Request.Candidate
{
    /// <summary>
    /// Clase Candidate Create Request
    /// </summary>
    public class CandidateCreateRequest : RequestBaseImpl, IRequest<CandidateCreateResponse>
    {
        /// <summary>
        /// Id de Evento
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public int IdEvent { get; set; }

        /// <summary>
        /// Id de Usuario a Candidato
        /// </summary>
        /// <value></value>
        public int IdUser { get; set; }
    }
}
