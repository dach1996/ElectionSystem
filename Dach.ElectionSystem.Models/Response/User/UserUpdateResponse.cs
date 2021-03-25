﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Models.Response.User
{
    /// <summary>
    /// Clase respuesta de Update Usuario
    /// </summary>
    public class UserUpdateResponse  : UserResponseBase
    {
        /// <summary>
        /// Id de usuario
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Contraseña Usuario
        /// </summary>
        [JsonIgnore]
        public new string Password { get => ""; }
    }
}
