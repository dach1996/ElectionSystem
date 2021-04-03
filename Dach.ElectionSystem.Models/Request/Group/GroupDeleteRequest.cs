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
        /// Contexto de Datos
        /// </summary>
        /// <value></value>
        public TokenModel TokenModel { get ; set ; }
    }
}