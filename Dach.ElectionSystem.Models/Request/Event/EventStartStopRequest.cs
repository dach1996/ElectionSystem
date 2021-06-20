using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Models.Response.Event;
using MediatR;
namespace Dach.ElectionSystem.Models.Request.Event
{
    /// <summary>
    /// Clase EventStartStop
    /// </summary>
    public class EventStartStopRequest : RequestBaseImpl, IRequest<EventStartStopResponse>
    {
        /// <summary>
        /// Id de Evento
        /// </summary>
        [JsonIgnore]
        public int IdEvent { get; set; }

        /// <summary>
        /// Dias Permitidos para votación
        /// </summary>
        /// <value></value>
        public int DaysAllow { get; set; }
    }
}
