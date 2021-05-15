
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dach.ElectionSystem.Models.Persitence
{
    /// <summary>
    /// Clase de Persistencia Imagenes de candidatos
    /// </summary>
    [Table(name: "CANDIDATO_IMAGENES")]
    public class CandidateImage
    {
        #region Attributes

        /// <summary>
        /// Id de imagen de dandidato
        /// </summary>
        /// <value></value>
        [Key, Column("CAN_IMG_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Id del evento
        /// </summary>
        /// <value></value>
        [Column("CAN_IMG_EVT_ID")]
        [ForeignKey(nameof(Event))]
        public int IdEvent { get; set; }

        /// <summary>
        ///  Id del candidato
        /// </summary>
        /// <value></value>
        [Column("CAN_IMG_CAN_ID")]
        [ForeignKey(nameof(Candidate))]
        public int IdCandidate { get; set; }

        /// <summary>
        /// Ambiente
        /// </summary>
        /// <value></value>
        [Column("CAN_IMG_AMBIENTE")]
        public string Environment { get; set; }

        /// <summary>
        ///  Imagen
        /// </summary>
        /// <value></value>
        [Column("CAN_IMG_IMAGEN")]
        public string Image { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Obtener la ruta completa de la imagen
        /// </summary>
        /// <value></value>
        public string ImageFullPath { get=>$"{Environment}/{Image}";}
        #endregion

        #region Relations
        /// <summary>
        /// Relación con Evento
        /// </summary>
        /// <value></value>
        public Event Event { get; set; }

        /// <summary>
        /// Relación con Candidato
        /// </summary>
        /// <value></value>
        public Candidate Candidate { get; set; }
        #endregion
    }
}