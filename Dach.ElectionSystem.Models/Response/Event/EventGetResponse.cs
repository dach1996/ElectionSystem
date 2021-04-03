using System.Collections.Generic;
using Dach.ElectionSystem.Models.Base;

namespace Dach.ElectionSystem.Models.Response.Event
{
    /// <summary>
    /// Clase EventGetResponse
    /// </summary>
    public class EventGetResponse
    {
        /// <summary>
        /// Lista de Eventos
        /// </summary>
        /// <value></value>
        public List<EventResponseBase> ListEvents { get; set; }
        
        
    }
}