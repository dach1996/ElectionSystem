using Dach.ElectionSystem.Models.Response.User;
using Dach.ElectionSystem.Models.Response.Vote;
using MediatR;
using System.Text.Json.Serialization;


namespace Dach.ElectionSystem.Models.Request.Vote
{
    /// <summary>
    /// Clase Request para Update Usuario
    /// </summary>
    public class VoteUpdateRequest : VoteBaseRequest, IRequest<VoteUpdateResponse>
    {
       /// <summary>
        /// Id de Evento
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public int IdCandidate { get; set; }
    }
}
