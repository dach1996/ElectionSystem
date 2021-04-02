using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dach.ElectionSystem.Models.Persitence
{
    /// <summary>
    /// Mapeo de Tabla Usuarios
    /// </summary>
    [Table(name: "USUARIOS")]
    public class User
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public User()  {
            this.AdministratorEvent = new List<AdministratorEvent>();
            this.IsActive = true;
        }
        /// <summary>
        /// Id único usuario
        /// </summary>
        [Key, Column("USU_ID")] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        /// <summary>
        /// Cédula Usuario
        /// </summary>
        [Column("USU_CEDULA")] public string DNI { get; set; }
        /// <summary>
        /// Nick Usuario
        /// </summary>
        [Column("USU_NICK")] public string UserName { get; set; }
        /// <summary>
        /// Contraseña Usuario
        /// </summary>
        [Column("USU_PASSWORD")] public string Password { get; set; }
        /// <summary>
        /// Primer nombre Usuario
        /// </summary>
        [Column("USU_NOMBRE")] public string FirstName { get; set; }
        /// <summary>
        /// Segundo nombre Usuario
        /// </summary>
        [Column("USU_SEGUNDO_NOMBRE")] public string SecondName { get; set; }
        /// <summary>
        /// Primer Apellido Usuario
        /// </summary>
        [Column("USU_APELLIDO")] public string FirstLastName { get; set; }
        /// <summary>
        /// Segundo Apellido Usuario
        /// </summary>
        [Column("USU_SEGUNDO_APELLIDO")] public string SecondLastName { get; set; }
        /// <summary>
        /// Fecha de nacimiento Usuario
        /// </summary>
        [Column("USU_FECHA_NACIMIENTO")] public DateTime? BirthDate { get; set; }
        /// <summary>
        /// Email Usuario
        /// </summary>
        [Column("USU_CORREO")] public string Email { get; set; }

        /// <summary>
        /// Estado de Usuario
        /// </summary>
        [Column("USU_ESTADO")] public bool IsActive { get; set; }

        /// <summary>
        /// Estado de Usuario
        /// </summary>
        [Column("USU_NUM_EVENT_MAX")] public int MaxEventsAllow { get; set; } = 1;

        /// <summary>
        /// Eventos Usuarios
        /// </summary>
        /// <value></value>
        public virtual List<AdministratorEvent> AdministratorEvent { get; set; }
    }
}
