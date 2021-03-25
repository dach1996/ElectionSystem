using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Models.Enums
{
    /// <summary>
    /// Patrones de seguridad Disponibles
    /// </summary>
    public enum Claim
    {
        /// <summary>
        /// Nombre de usuario
        /// </summary>
        Name,
        /// <summary>
        /// Rol de Usuario
        /// </summary>
        Role,
        /// <summary>
        /// Fecha de Cumpleaños
        /// </summary>
        BirthDate,
        /// <summary>
        /// Email de Usuario
        /// </summary>
        Email
    }
}
