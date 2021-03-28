using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Models.Base
{
    /// <summary>
    /// Clase base para Usuarios
    /// </summary>
    public class UserBase
    {
        /// <summary>
        /// Cédula Usuario
        /// </summary>
        public string DNI { get; set; }
        /// <summary>
        /// Nick Usuario
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Contraseña Usuario
        /// </summary>
        public virtual string Password { get; set; }
        /// <summary>
        /// Primer nombre Usuario
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Segundo nombre Usuario
        /// </summary>
        public string SecondName { get; set; }
        /// <summary>
        /// Primer Apellido Usuario
        /// </summary>
        public string FirstLastName { get; set; }
        /// <summary>
        /// Segundo Apellido Usuario
        /// </summary>
        public string SecondLastName { get; set; }
        /// <summary>
        /// Fecha de nacimiento Usuario
        /// </summary>
        public DateTime? BirthDate { get; set; }
        /// <summary>
        /// Email Usuario
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Rol de Usuario
        /// </summary>
        public Models.Enums.RolUser Role { get; set; }
    }
}
