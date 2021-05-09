using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Models.Response.Vote;
using MediatR;
namespace Dach.ElectionSystem.Models.Request.Vote

{
    /// <summary>
    /// Request para crear Usuarios
    /// </summary>
    public class VoteAutoCreateRequest : RequestBaseImpl, IRequest<VoteAutoCreateResponse>
    {
        /// <summary>
        /// Id de Evento
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public int IdEvent { get; set; }

        /// <summary>
        /// Código único del evento para poder registrarme
        /// </summary>
        /// <value></value>
        public string CodeEvent { get; set; }
    }
}
