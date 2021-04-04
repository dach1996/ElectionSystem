using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Models.Response.User;
using MediatR;

namespace Dach.ElectionSystem.Models.Request.User
{
    /// <summary>
    /// Clase para Request Delete User
    /// </summary>
    public class UserDeleteRequest : RequestBaseImpl, IRequest<UserDeleteResponse>
    {
        /// <summary>
        /// Id de usuario
        /// </summary>
        public int Id { get; set; }

    }
}
