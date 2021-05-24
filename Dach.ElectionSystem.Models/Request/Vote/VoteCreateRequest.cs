using System;
using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.Enums;
using Dach.ElectionSystem.Models.Request.Methods;
using Dach.ElectionSystem.Models.Response.Vote;
using MediatR;
namespace Dach.ElectionSystem.Models.Request.Vote

{
    /// <summary>
    /// Request para crear Usuarios
    /// </summary>
    public class VoteCreateRequest : VoteBaseRequest, IRequest<VoteCreateResponse>
    {

        /// <summary>
        /// Id de Evento
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public int IdUser { get; set; }

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
