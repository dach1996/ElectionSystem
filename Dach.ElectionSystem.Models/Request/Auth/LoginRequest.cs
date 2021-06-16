using Dach.ElectionSystem.Models.Response.Auth;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dach.ElectionSystem.Models.Auth
{
    /// <summary>
    /// Clase modelo para Request de Login
    /// </summary>
    public class LoginRequest : IRequest<LoginResponse>
    {
        /// <summary>
        /// Email del usuario
        /// </summary>
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        [Required]
        public string Password { get; set; }
                public object prueba { get; set; }
    }
}
