using System.ComponentModel.DataAnnotations;

namespace Dach.ElectionSystem.Models.Base
{
    /// <summary>
    /// Clase base para candidato
    /// </summary>
    public class CandidateBase
    {
        /// <summary>
        /// Video del Candidato
        /// </summary>
        /// <value></value>
        public string Video { get; set; }
        /// <summary>
        /// Detalles de Candidato
        /// </summary>
        /// <value></value>
        [Required]
        public string Details { get; set; }
        /// <summary>
        /// Rol de candidato en el Evento
        /// </summary>
        /// <value></value>
        [Required]
        public string Role { get; set; }
        /// <summary>
        /// Edad del candidato
        /// </summary>
        /// <value></value>
        [Required]
        public int? Age { get; set; }
        /// <summary>
        /// Propuesta de candidato
        /// </summary>
        /// <value></value>
        [Required]
        public string ProposalDetails { get; set; }
        /// <summary>
        /// Posiciones de trabajo 
        /// </summary>
        /// <value></value>
        public string PostionsWorks { get; set; }

    }
}