
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dach.ElectionSystem.Models.Persitence
{
    /// <summary>
    /// Clase de Persistencia Candidatos
    /// </summary>
    [Table(name: "CANDIDATOS")]
    public class Candidate
    {
        #region Attributes

        /// <summary>
        /// Id Candidato
        /// </summary>
        /// <value></value>
        [Key, Column("CAN_IDS")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Ruta de imagen Candidato
        /// </summary>
        /// <value></value>
        [Column("CAN_IMAGEN")]
        public string Image { get; set; }
        /// <summary>
        /// Ruta Video de Candidato
        /// </summary>
        /// <value></value>
        [Column("CAN_VIDEO")]
        public string Video { get; set; }
        /// <summary>
        /// Detalles de Candidato
        /// </summary>
        /// <value></value>
        [Column("CAN_DETALLES")]
        public string Details { get; set; }
        /// <summary>
        /// Rol de Candidato
        /// </summary>
        /// <value></value>
        [Column("CAN_ROL")]
        public string Role { get; set; }
        /// <summary>
        /// Edad de Candidato
        /// </summary>
        /// <value></value>
        [Column("CAN_EDAD")]
        public int Age { get; set; }
        /// <summary>
        /// Propuesta de Candidato
        /// </summary>
        /// <value></value>
        [Column("CAN_PROPUESTA")]
        public string ProposalDetails { get; set; }
        /// <summary>
        /// Puestos Laborales de candidato
        /// </summary>
        /// <value></value>
        [Column("CAN_PUESTOS_LABORALES")]
        public string PostionsWorks { get; set; }
        /// <summary>
        /// Estado de Candidato
        /// </summary>
        [Column("CAN_ESTADO")]
        public bool IsActive { get; set; }
        /// <summary>
        /// Id del evento
        /// </summary>
        /// <value></value>
        [Column("CAN_GRP_ID")]
        [ForeignKey(nameof(Group))]
        public int IdGroup { get; set; }
        /// <summary>
        ///  Id del Usuario
        /// </summary>
        /// <value></value>
        [Column("CAN_USU_ID")]
        [ForeignKey(nameof(User))]
        public int IdUser { get; set; }
        #endregion

        #region Relations
        /// <summary>
        /// Relación con Evento
        /// </summary>
        /// <value></value>
        public Group Group { get; set; }
        /// <summary>
        /// Relación con Usuario
        /// </summary>
        /// <value></value>
        public User User { get; set; }
        #endregion
    }
}