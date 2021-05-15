using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.RequestBase;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Dach.ElectionSystem.Models.Request.Candidate
{
    /// <summary>
    /// Clase cargar imágenes del candidato
    /// </summary>
    public class CandidateImageRequest : IRequestBase, IRequest<Unit>
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

        /// <summary>
        /// Clase contexto de Token
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public TokenModel TokenModel { get; set; }

        /// <summary>
        /// Contexto de Usuario
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public Persitence.User UserContext { get; set; }

        /// <summary>
        /// Path de server
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public string PartRoot { get; set; }
    }
}