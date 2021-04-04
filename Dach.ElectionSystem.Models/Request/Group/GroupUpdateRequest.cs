using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.Response.Group;
using MediatR;

namespace Dach.ElectionSystem.Models.Request.Group
{
    /// <summary>
    /// Clase GroupUpdateRequest
    /// </summary>
    public class GroupUpdateRequest : GroupBaseRequest, IRequest<GroupUpdateResponse>
    {


        /// <summary>
        /// Estado de Grupo
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Ide de grupo
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public int IdGroup { get; set; }

        /// <summary>
        /// Id del Evento
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public int IdEvent { get; set; }
    }
}