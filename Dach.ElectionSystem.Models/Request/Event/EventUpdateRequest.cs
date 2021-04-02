using System.Globalization;
using Dach.ElectionSystem.Models.Response.Event;
using MediatR;

namespace Dach.ElectionSystem.Models.Request.Event
{
    /// <summary>
    /// Clase EventUpdateRequest
    /// </summary>
    public class EventUpdateRequest : EventBaseRequest, IRequest<EventUpdateResponse>
    {
        /// <summary>
        /// Evento Activo
        /// </summary>
        public bool IsActive { get; set; }
    }
}