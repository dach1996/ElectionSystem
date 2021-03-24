using Dach.ElectionSystem.Models.Request.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Models.Response.User
{
    /// <summary>
    /// Response para crear usuario
    /// </summary>
    public class UserCreateResponse : UserCreateRequest
    {
        /// <summary>
        /// Id de usuario
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Contraseña Usuario
        /// </summary>
        public new string Password { get =>""; }
    }
}
