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
        /// Rol del Usuario
        /// </summary>
        public Models.Enums.RolUser RolUser  { get; set; }
        
        /// <summary>
        /// Nombre de usuario
        /// </summary>
        public string username  { get; set; }
    }
}
