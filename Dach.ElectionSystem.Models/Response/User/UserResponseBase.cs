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
    public  class UserResponseBase : UserBase
    {

        
        /// <summary>
        /// Contraseña Usuario
        /// </summary>
        [JsonIgnore]
        public override string Password { get => ""; }

           /// <summary>
        /// Id de usuario
        /// </summary>
        public int Id { get; set; }

               /// <summary>
        /// Estado del Usuario
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Número maximo de eventos permitidos
        /// </summary>
        public int MaxEventsAllow { get; set; }
    }
}
