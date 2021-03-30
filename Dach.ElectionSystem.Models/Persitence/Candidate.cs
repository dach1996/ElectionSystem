
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

        /// <summary>
        /// Id Candidato
        /// </summary>
        /// <value></value>
        [Key, Column("ID_CANDIDATOS")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// Ruta de imagen Candidato
        /// </summary>
        /// <value></value>
        [Column("IMAGEN_CANDIDATO")]
        public string Image { get; set; }
        /// <summary>
        /// Ruta Video de Candidato
        /// </summary>
        /// <value></value>
        [Column("VIDEO_CANDIDATO")]
        public string Video { get; set; }
        /// <summary>
        /// Detalles de Candidato
        /// </summary>
        /// <value></value>
        [Column("DETALLES_CANDIDATO")]
        public string Details { get; set; }
        /// <summary>
        /// Rol de Candidato
        /// </summary>
        /// <value></value>
        [Column("ROL_CANDIDATO")]
        public string Role { get; set; }
        /// <summary>
        /// Edad de Candidato
        /// </summary>
        /// <value></value>
        [Column("EDAD_CANDIDATO")]
        public int Age { get; set; }
        /// <summary>
        /// Propuesta de Candidato
        /// </summary>
        /// <value></value>
        [Column("PROPUESTA_CANDIDATO")]
        public string ProposalDetails { get; set; }
        /// <summary>
        /// Puestos Laborales de candidato
        /// </summary>
        /// <value></value>
        [Column("PUESTOS_LABORALES_CANDIDATO")]
        public string PostionsWorks { get; set; }
        /// <summary>
        /// Estado de Candidato
        /// </summary>
        [Column("ESTADO_CANDIDATO")] 
        public bool IsActive { get; set; }
    }
}