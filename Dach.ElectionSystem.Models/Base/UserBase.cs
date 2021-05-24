using System;
using System.ComponentModel.DataAnnotations;

namespace Dach.ElectionSystem.Models.Base
{
    /// <summary>
    /// Clase base para Usuarios
    /// </summary>
    public abstract class UserBase
    {
        /// <summary>
        /// Cédula Usuario
        /// </summary>
        [Required]
        public virtual string DNI { get; set; }

        /// <summary>
        /// Nick Usuario
        /// </summary>
        [Required]
        public virtual string UserName { get; set; }

        /// <summary>
        /// Contraseña Usuario
        /// </summary>
     
        public virtual string Password { get; set; }

        /// <summary>
        /// Primer nombre Usuario
        /// </summary>
        [Required]
        public virtual string FirstName { get; set; }
        /// <summary>
        /// Segundo nombre Usuario
        /// </summary>
        public virtual string SecondName { get; set; }

        /// <summary>
        /// Primer Apellido Usuario
        /// </summary>
        [Required]
        public virtual string FirstLastName { get; set; }

        /// <summary>
        /// Segundo Apellido Usuario
        /// </summary>
        public virtual string SecondLastName { get; set; }

        /// <summary>
        /// Fecha de nacimiento Usuario
        /// </summary>
        [Required]
        public virtual DateTime? BirthDate { get; set; }

        /// <summary>
        /// Email Usuario
        /// </summary>
 
        public virtual string Email { get; set; }
    }
}
