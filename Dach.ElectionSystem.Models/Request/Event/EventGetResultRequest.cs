using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Models.Response.Event;
using MediatR;

namespace Dach.ElectionSystem.Models.Request.Event
{
    /// <summary>
    /// Clase Event Get Request
    /// </summary>
    public class EventGetResultRequest : RequestBaseImpl, IRequest<EventGetResultResponse>
    {
        /// <summary>
        /// Id del evento
        /// </summary>
        /// <value></value>
        public int IdEvent { get; set; }
    }
}