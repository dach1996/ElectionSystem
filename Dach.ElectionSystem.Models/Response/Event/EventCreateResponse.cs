using Dach.ElectionSystem.Models.Base;

namespace Dach.ElectionSystem.Models.Response.Event
{
    /// <summary>
    /// Clase EventCreateResponse
    /// </summary>
    public class EventCreateResponse : EventBase
    {
        /// <summary>
        /// Estado de Evento
        /// </summary>
        /// <value></value>
        public bool IsActive { get; set; }

    }
}
