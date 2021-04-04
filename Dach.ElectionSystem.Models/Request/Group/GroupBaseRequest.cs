using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.Base;
using Dach.ElectionSystem.Models.RequestBase;

namespace Dach.ElectionSystem.Models.Request.Group
{

    /// <summary>
    /// Clase Base GroupBaseRequest
    /// </summary>
    public class GroupBaseRequest : GroupBase, IRequestBase
    {
        /// <summary>
        /// Contexto de Datos
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public TokenModel TokenModel { get ; set ; }
              /// <summary>
        /// Contexto de Usuario
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public Persitence.User UserContext { get; set; }
    }
}