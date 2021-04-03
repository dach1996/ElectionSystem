using Dach.ElectionSystem.Models.Response.Group;
using MediatR;

namespace Dach.ElectionSystem.Models.Request.Group
{
    /// <summary>
    /// Clase GroupCreateRequest
    /// </summary>
    public class GroupCreateRequest : GroupBaseRequest, IRequest<GroupCreateResponse>
    {
        
    }
}