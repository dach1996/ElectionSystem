using System.ComponentModel.DataAnnotations;
using Dach.ElectionSystem.Models.Enums;
using Dach.ElectionSystem.Models.Request.Methods;
using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Models.Response.Candidate;
using MediatR;
namespace Dach.ElectionSystem.Models.Request.Candidate
{
    /// <summary>
    /// Clase CandidateGetRequest
    /// </summary>
    public class CandidateGetRequest : RequestBaseImpl, IRequest<CandidateGetResponse>, IGetRequest
    {
        /// <summary>
        /// Id de Evento
        /// </summary>
        /// <value></value>
        public int IdEvent { get; set; }

        /// <summary>
        /// Id de Candidato
        /// </summary>
        /// <value></value>
        public int? IdUser { get; set; }

        /// <summary>
        /// Paginación
        /// </summary>
        /// <value></value>
        [Required]
        [Range(0, int.MaxValue)]
        public int Offset { get; set; }

        /// <summary>
        /// Orden de Consulta
        /// </summary>
        /// <value></value>
        [Required]
        public OrderBy? OrderBy { get; set; }

        /// <summary>
        /// Cantidad de Registros
        /// </summary>
        /// <value></value>
        [Required]
        [Range(1, int.MaxValue)]
        public int Limit { get; set; }

        /// <summary>
        /// Total de candidatos en el evento
        /// </summary>
        /// <value></value>
        public int TotalCandidates { get; set; }
    }
}
