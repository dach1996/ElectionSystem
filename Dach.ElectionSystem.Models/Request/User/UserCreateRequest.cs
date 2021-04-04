using Dach.ElectionSystem.Models.Response.User;
using MediatR;


namespace Dach.ElectionSystem.Models.Request.User
{
    /// <summary>
    /// Request para crear Usuarios
    /// </summary>
    public class UserCreateRequest : UserRequestBase, IRequest<UserCreateResponse>
    {
 
    }
}
