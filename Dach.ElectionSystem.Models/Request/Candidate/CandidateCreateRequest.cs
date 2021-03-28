using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Models.Response.Candidate;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dach.ElectionSystem.Models.Request.Candidate
{
    /// <summary>
    /// Clase Candidate Create Request
    /// </summary>
    public class CandidateCreateRequest : IRequest<CandidateCreateResponse>, IRequestBase
    {
        /// <summary>
        /// Imagen del candidato
        /// </summary>
        /// <value></value>
        public string Image { get; set; }
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
        public int Age { get; set; }
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
        /// <summary>
        /// Clase contexto de Token
        /// </summary>
        /// <value></value>
        public TokenModel TokenModel { get ; set; }
    }
}
