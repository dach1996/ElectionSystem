using System;
using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Models.Response.Vote;
using MediatR;

namespace Dach.ElectionSystem.Models.Request.Vote
{
    /// <summary>
    /// Clase para Request Delete User
    /// </summary>
    public class VoteDeleteRequest : RequestBaseImpl, IRequest<VoteDeleteResponse>
    {
        /// <summary>
        /// Id de Usuario
        /// </summary>
        [JsonIgnore]
        public int IdUser { get; set; }
        
        /// <summary>
        /// Id de Event
        /// </summary>
        [JsonIgnore]
        public int IdEvent { get; set; }
    }
}
