using System.Collections.Generic;

namespace Dach.ElectionSystem.Models.Response.Event
{
    /// <summary>
    /// Clase EventGetResponse
    /// </summary>
    public class EventGetResponse
    {
        /// <summary>
        /// Número total de evento
        /// </summary>
        /// <value></value>
        public int TotalEvents { get; set; }
        
        
        /// <summary>
        /// Lista de Eventos
        /// </summary>
        /// <value></value>
        public List<EventBaseResponse> ListEvents { get; set; }
    }
}