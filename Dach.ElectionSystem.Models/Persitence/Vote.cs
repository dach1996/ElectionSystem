using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dach.ElectionSystem.Models.Persitence
{
    /// <summary>
    /// Clase para persistencia de votos
    /// </summary>
    public class Vote
    {
        #region Attributes
            /// <summary>
        /// Id único usuario
        /// </summary>
        [Key, Column("VTO_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Cédula Usuario
        /// </summary>
        [Column("VTO_EVT_ID")]
        [ForeignKey(nameof(Event))]
        public int IdEvent { get; set; }
        /// <summary>
        /// Cédula Usuario
        /// </summary>
        [Column("VTO_USU_ID")]
        [ForeignKey(nameof(User))]
        public int IdUser { get; set; }
        /// <summary>
        /// Cédula Usuario
        /// </summary>
        [Column("VTO_GRP_ID")]
        [ForeignKey(nameof(Group))]
        public int IdGroup { get; set; }
        /// <summary>
        /// Cédula Usuario
        /// </summary>
        [Column("VTO_FECHA")]
        public DateTime Date { get; set; }
        /// <summary>
        /// Cédula Usuario
        /// </summary>
        [Column("VTO_ESTADO")]
        public bool HasVote { get; set; }
        #endregion

        #region Relations
        /// <summary>
        /// Relación con Evento
        /// </summary>
        /// <value></value>
        public Event Event { get; set; }
        /// <summary>
        /// Relación con Usuario
        /// </summary>
        /// <value></value>
        public User  User { get; set; }
        /// <summary>
        /// Relación con Grupo
        /// </summary>
        /// <value></value>
        public Group Group { get; set; }     
        #endregion  
    }
}