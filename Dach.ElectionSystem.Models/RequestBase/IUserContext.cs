using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.Persitence;

namespace Dach.ElectionSystem.Models.RequestBase
{
    /// <summary>
    /// Contexto de Usuario
    /// </summary>
    public interface IUserContext
    {
        /// <summary>
        /// Token para contexto
        /// </summary>
        [JsonIgnore]
        User UserContext { get; set; }
    }
}