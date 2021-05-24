using Dach.ElectionSystem.Models.Response.Vote;
using MediatR;
using System;
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

        /// <summary>
        /// Cédula Usuario
        /// </summary>
        [JsonIgnore]
        public override DateTime? Date { get; set; }

        /// <summary>
        /// Cédula Usuario
        /// </summary>
        [JsonIgnore]
        public override bool HasVote { get; set; }
    }
}
