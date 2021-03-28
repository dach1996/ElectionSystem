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
    /// Request para crear Usuarios
    /// </summary>
    public class UserCreateRequest : UserRequestBase, IRequest<UserCreateResponse>
    {
        /// <summary>
        /// Estado de Usuario
        /// </summary>
        [JsonIgnore]
        public bool IsActive { get; set; }
    }
}
