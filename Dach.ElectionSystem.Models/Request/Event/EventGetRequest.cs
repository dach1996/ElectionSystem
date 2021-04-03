using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.Response.Event;
using MediatR;

namespace Dach.ElectionSystem.Models.Request.Event
{
    /// <summary>
    /// Clase Event Get Request
    /// </summary>
    public class EventGetRequest : EventBaseRequest, IRequest<EventGetResponse>
    {
        /// <summary>
        /// Id de Evento
        /// </summary>
        /// <value></value>
        public int? Id { get; set; }
    }
}