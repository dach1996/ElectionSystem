using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Models.RequestBase
{
    /// <summary>
    /// Modelo Token para inyectar en Contexto
    /// </summary>
    public class TokenModel
    {        
        /// <summary>
        /// Nombre de usuario
        /// </summary>
        public string Username  { get; set; }
       
        /// <summary>
        /// Email de usuario
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Id de Usuario
        /// </summary>
        public string Id { get; set; }
    }
}
