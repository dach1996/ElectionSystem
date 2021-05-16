using System.Text.Json.Serialization;

namespace Dach.ElectionSystem.Models.RequestBase
{
    /// <summary>
    /// Clase base para todos los request
    /// </summary>
    public interface IRequestBase : IUserContext
    {
        /// <summary>
        /// Token para contexto
        /// </summary>
        TokenModel TokenModel { get; set; }
        /// <summary>
        /// Path de server
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        string PathRoot { get; set; }

    }
}
