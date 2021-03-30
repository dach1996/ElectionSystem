using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.Base;
using Dach.ElectionSystem.Models.RequestBase;

namespace Dach.ElectionSystem.Models.Request.Event
{
    /// <summary>
    /// Clase base para Request de Evento
    /// </summary>
    public class EventBaseRequest : EventBase, IRequestBase
    {
        /// <summary>
        /// Clase contexto de Token
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public TokenModel TokenModel { get; set; }
    }
}