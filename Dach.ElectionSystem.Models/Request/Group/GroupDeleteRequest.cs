using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Models.Response.Group;
using MediatR;

namespace Dach.ElectionSystem.Models.Request.Group
{
    /// <summary>
    /// Clase GroupDeleteRequest
    /// </summary>
    public class GroupDeleteRequest : IRequestBase, IRequest<GroupDeleteResponse>
    {
        /// <summary>
        /// Id del Evento
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public int IdEvent { get; set; }

        /// <summary>
        /// Id del Grupo
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public int IdGroup { get; set; }

        /// <summary>
        /// Contexto de Datos
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public TokenModel TokenModel { get; set; }
    }
}