using Dach.ElectionSystem.Models.Response.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dach.ElectionSystem.Models.Auth
{
    /// <summary>
    /// Clase modelo para Request de Login
    /// </summary>
    public class LoginRequest : IRequest<LoginResponse>
    {
        /// <summary>
        /// Usuario
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
    }
}
