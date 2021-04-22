using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Models.Response.EventAdministrator;
using MediatR;

namespace Dach.ElectionSystem.Models.Request.EventAdministrator
{
    /// <summary>
    /// Clase EventAdministrator Get Request
    /// </summary>
    public class EventAdministratorGetRequest : RequestBaseImpl, IRequest<EventAdministratorGetResponse>
    {      
        
        /// <summary>
        /// Id Evento
        /// </summary>
        /// <value></value>
         [JsonIgnore]
        public int IdEvent { get; set; }

    }
}