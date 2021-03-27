using Dach.ElectionSystem.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Models.Response.User
{
    /// <summary>
    /// Clase base para respuesta de Usuario
    /// </summary>
    public abstract class UserResponseBase : UserBase
    {

        /// <summary>
        /// Contraseña Usuario
        /// </summary>
        [JsonIgnore]
        public new string Password { get => ""; }
    }
}
