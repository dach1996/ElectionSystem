using System.ComponentModel.DataAnnotations;
using Dach.ElectionSystem.Models.RequestBase;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Dach.ElectionSystem.Models.Request.Candidate
{
    /// <summary>
    /// Clase cargar imágenes del candidato
    /// </summary>
    public class CandidateImageRequest : RequestBaseImpl, IRequest<Unit>
    {
        /// <summary>
        /// Imagen a Cargar
        /// </summary>
        /// <value></value>
        [Required]
        public IFormFile Image { get; set; }

        /// <summary>
        /// Id del evento
        /// </summary>
        /// <value></value>
        public int IdEvent { get; set; }
    }
}