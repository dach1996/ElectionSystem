using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.Persitence;

namespace Dach.ElectionSystem.Models.RequestBase
{
    /// <summary>
    /// Clase Base de Request
    /// </summary>
    public class RequestBaseImpl : IRequestBase
    {
        /// <summary>
        /// Token Model
        /// </summary>
        /// <returns></returns>
        [JsonIgnore]
        public TokenModel TokenModel { get; set; }
        /// <summary>
        /// Usuario del Contexto
        /// </summary>
        /// <returns></returns>
        [JsonIgnore]
        public User UserContext { get; set; }


        /// <summary>
        /// Path de server
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public string PartRoot { get; set; }
    }
}