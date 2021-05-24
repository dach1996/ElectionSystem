using System.ComponentModel.DataAnnotations;
using Dach.ElectionSystem.Models.Response.User;
using MediatR;


namespace Dach.ElectionSystem.Models.Request.User
{
    /// <summary>
    /// Request para crear Usuarios
    /// </summary>
    public class UserCreateRequest : UserRequestBase, IRequest<UserCreateResponse>
    {
        /// <summary>
        /// Email Usuario
        /// </summary>
        [Required]
        override public string Email { get; set; }

        /// <summary>
        /// Constraseña de Usuario
        /// </summary>
        [Required]
        override public string Password { get; set; }
    }
}
