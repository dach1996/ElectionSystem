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
        /// Id único usuario
        /// </summary>
        [Key, Column("ID_USUARIO")] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }
        /// <summary>
        /// Cédula Usuario
        /// </summary>
        [Column("CEDULA_USUARIO")] public string DNI { get; set; }
        /// <summary>
        /// Nick Usuario
        /// </summary>
        [Column("NICK_USUARIO")] public string UserName { get; set; }
        /// <summary>
        /// Contraseña Usuario
        /// </summary>
        [Column("PASSWORD_USUARIO")] public string Password { get; set; }
        /// <summary>
        /// Primer nombre Usuario
        /// </summary>
        [Column("NOMBRE_USUARIO")] public string FirstName { get; set; }
        /// <summary>
        /// Segundo nombre Usuario
        /// </summary>
        [Column("SEGUNDO_NOMBRE_USUARIO")] public string SecondName { get; set; }
        /// <summary>
        /// Primer Apellido Usuario
        /// </summary>
        [Column("APELLIDO_USUARIO")] public string FirstLastName { get; set; }
        /// <summary>
        /// Segundo Apellido Usuario
        /// </summary>
        [Column("SEGUNDO_APELLIDO_USUARIO")] public string SecondLastName { get; set; }
        /// <summary>
        /// Fecha de nacimiento Usuario
        /// </summary>
        [Column("FECHA_NACIMIENTO_USUARIO")] public DateTime? BirthDate { get; set; }
        /// <summary>
        /// Email Usuario
        /// </summary>
        [Column("CORREO_USUARIO")] public string Email { get; set; }
        /// <summary>
        /// Rol de Usuario
        /// </summary>
        [Column("ROL_USUARIO")] public int? Rol { get; set; }
        /// <summary>
        /// Rol de Usuario
        /// </summary>
        [Column("NOMBRE_ROL_USUARIO")] public string RolName { get; set; }
        /// <summary>
        /// Estado de Usuario
        /// </summary>
        [Column("ESTADO_USUARIO")] public bool IsActive { get; set; }
     
        /// <summary>
        /// Eventos Usuarios
        /// </summary>
        /// <value></value>
        public virtual  List<EventUser> EventUser { get; set; }
    }
}
