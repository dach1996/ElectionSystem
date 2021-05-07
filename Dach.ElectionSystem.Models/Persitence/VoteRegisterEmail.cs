using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dach.ElectionSystem.Models.Persitence
{
    /// <summary>
    /// Clase para persistencia de votos
    /// </summary>
    [Table(name: "VOTOS_REGISTRO_CORREO")]
    public class VoteRegisterEmail
    {
        #region Attributes
        /// <summary>
        /// Id único usuario
        /// </summary>
        [Key, Column("VRC_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Id del evento
        /// </summary>
        [Column("VRC_EVT_ID")]
        public int IdEvent { get; set; }


        /// <summary>
        /// Correo del usuario
        /// </summary>
        [Column("VRC_USU_CORREO")]
        public string UserEmail { get; set; }
        
        /// <summary>
        /// Cédula Usuario
        /// </summary>
        [Column("VRC_USU_ASIGNADOR_ID")]
        public int IdUserAdministrator { get; set; }
        #endregion
    }
}