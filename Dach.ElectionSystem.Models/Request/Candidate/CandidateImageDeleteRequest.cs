using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.RequestBase;
using MediatR;
namespace Dach.ElectionSystem.Models.Request.Candidate
{
    /// <summary>
    /// Clase cargar imágenes del candidato
    /// </summary>
    public class CandidateImageDeleteRequest : IRequestBase, IRequest<Unit>
    {
        /// <summary>
        ///  Nombre de imagen a Borrar
        /// </summary>
        /// <value></value>
        [Required]
        public string NameResoruce { get; set; }

        /// <summary>
        /// Id del evento
        /// </summary>
        /// <value></value>
        [JsonIgnore]
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
        public string PathRoot { get; set; }
    }
}