using System.Collections.Generic;
using Dach.ElectionSystem.Models.Base;

namespace Dach.ElectionSystem.Models.Response.EventAdministrator
{
    /// <summary>
    /// Clase EventAdministratorGetResponse
    /// </summary>
    public class EventAdministratorGetResponse
    {
        /// <summary>
        /// Lista de EventAdministratoros
        /// </summary>
        /// <value></value>
        public List<EventAdministratorResponseBase> ListEventAdministrators { get; set; }
        
        
    }
}