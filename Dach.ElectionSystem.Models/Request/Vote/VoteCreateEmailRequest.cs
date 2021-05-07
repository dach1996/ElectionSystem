using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.Response.Vote;
using MediatR;
namespace Dach.ElectionSystem.Models.Request.Vote

{
    /// <summary>
    /// Request para crear Usuarios
    /// </summary>
    public class VoteCreateEmailRequest : VoteBaseRequest, IRequest<VoteCreateEmailResponse>
    {

        /// <summary>
        /// Correo de Usuarios
        /// </summary>
        /// <value></value>
        
        public List<string> EmailUser { get; set; }

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
