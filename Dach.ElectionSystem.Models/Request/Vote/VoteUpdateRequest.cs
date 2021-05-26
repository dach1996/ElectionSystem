using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Models.Response.Vote;
using MediatR;
using System.Text.Json.Serialization;


namespace Dach.ElectionSystem.Models.Request.Vote
{
    /// <summary>
    /// Clase Request para Update Usuario
    /// </summary>
    public class VoteUpdateRequest : RequestBaseImpl, IRequest<VoteUpdateResponse>
    {
        /// <summary>
        /// Id de Candidato
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public int IdCandidate { get; set; }

        /// <summary>
        /// Id Evento
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public int IdEvent { get; set; }


    }
}
