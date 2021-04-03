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
        public int? Id { get; set; }
    }
}