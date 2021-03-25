using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Models.Response.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Models.Request.User
{
    /// <summary>
    /// Clase Request para Update Usuario
    /// </summary>
    public class UserUpdateRequest : UserRequestBase, IRequest<UserUpdateResponse>
    {
        /// <summary>
        /// Contraseña Usuario
        /// </summary>
        [JsonIgnore]
        private new string Password { get; set; }
        /// <summary>
        /// Email Usuario
        /// </summary>
        [JsonIgnore]
        private new string Email { get; set; }
        /// <summary>
        /// Rol de Usuario
        /// </summary>
        [JsonIgnore]
        private new  Models.Enums.RolUser Role { get; set; }
       
    }
}
