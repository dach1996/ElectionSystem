using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Models.Response.Event;
using MediatR;
namespace Dach.ElectionSystem.Models.Request.Event
{
    /// <summary>
    /// Clase EventDeleteRequest
    /// </summary>
    public class EventDeleteRequest : RequestBaseImpl, IRequest<EventDeleteResponse>
    {
        /// <summary>
        /// Id de Evento
        /// </summary>
        [JsonIgnore]
        public int IdEvent { get; set; }

    }
}
