using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.Response.Group;
using MediatR;

namespace Dach.ElectionSystem.Models.Request.Group
{
    /// <summary>
    /// Clase GroupGetRequest
    /// </summary>
    public class GroupGetRequest : GroupBaseRequest, IRequest<GroupGetResponse>
    {

        /// <summary>
        /// Ide de grupo
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public int? IdGroup { get; set; }

        /// <summary>
        /// Id de Evento
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public int? IdEvent { get; set; }
    }
}