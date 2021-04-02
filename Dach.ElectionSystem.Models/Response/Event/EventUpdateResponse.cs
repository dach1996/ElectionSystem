using Dach.ElectionSystem.Models.Base;

namespace Dach.ElectionSystem.Models.Response.Event
{
    /// <summary>
    /// Clase EventUpdateResponse
    /// </summary>
    public class EventUpdateResponse : EventBase
    {
        /// <summary>
        /// Estado de Evento
        /// </summary>
        /// <value></value>
        public bool IsActive { get; set; }
        
    }
}