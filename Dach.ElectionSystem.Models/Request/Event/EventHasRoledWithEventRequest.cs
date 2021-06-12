using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Models.Response.Event;
using MediatR;

namespace Dach.ElectionSystem.Models.Request.Event
{
    /// <summary>
    /// Clase Event Get Request
    /// </summary>
    public class EventHasRoledWithEventRequest : RequestBaseImpl, IRequest<EventHasRoledWithEventResponse>
    {
        /// <summary>
        /// Id de Evento
        /// </summary>
        /// <value></value>
        public int IdEvent { get; set; }
        
        /// <summary>
        /// Id de Usuario
        /// </summary>
        /// <value></value>
        public int IdUserComapare { get; set; }
    }
}