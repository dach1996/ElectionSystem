using System.Collections.Generic;

namespace Dach.ElectionSystem.Models.Response.Event
{
    /// <summary>
    /// Clase EventGetResponse
    /// </summary>
    public class EventHasRoledWithEventResponse
    {
        /// <summary>
        /// Tiene relación con el evento?
        /// </summary>
        /// <value></value>
        public bool HasRelationshipEvent  { get; set; }
    }
}