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
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public User()
        {
            this.ListEventAdministrator = new List<EventAdministrator>();
            this.ListCandidate = new List<Candidate>();
            this.IsActive = true;
            this.IsAdministrator = false;
        }
        #endregion

        #region Attributes
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
        /// Contraseña Usuario
        /// </summary>
        [Column("USU_TEM_PASSWORD")] public string TemPassword { get; set; }
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
        [Column("USU_ADMINISTRADOR")] public bool IsAdministrator { get; set; }

        #endregion

        #region Relations
        /// <summary>
        /// Lista de Eventos administradors por el usuario
        /// </summary>
        /// <value></value>
        public virtual List<EventAdministrator> ListEventAdministrator { get; set; }

        /// <summary>
        /// Lista de Candidatos que puede ser el usuario
        /// </summary>
        /// <value></value>
        public virtual List<Candidate> ListCandidate { get; set; }

        /// <summary>
        /// Relación con cantidad de eventos permitidos
        /// </summary>
        public virtual EventNumber EventNumber { get; set; }
        #endregion

    }
}
