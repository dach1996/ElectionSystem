using Dach.ElectionSystem.Models.Base;

namespace Dach.ElectionSystem.Models.Response.Event
{
    /// <summary>
    /// Clase base para respuestas
    /// </summary>
    public class EventResponseBase : EventBase
    {
        /// <summary>
        /// Estado de Evento
        /// </summary>
        /// <value></value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Id de Evento
        /// </summary>
        /// <value></value>
        public int id { get; set; }


    }
}