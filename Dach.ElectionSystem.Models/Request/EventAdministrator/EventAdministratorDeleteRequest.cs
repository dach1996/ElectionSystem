using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Models.Response.EventAdministrator;
using MediatR;
namespace Dach.ElectionSystem.Models.Request.EventAdministrator
{
    /// <summary>
    /// Clase EventAdministratorDeleteRequest
    /// </summary>
    public class EventAdministratorDeleteRequest : RequestBaseImpl, IRequest<EventAdministratorDeleteResponse>
    {
        /// <summary>
        /// Id Usuario
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public int IdUser { get; set; }


        /// <summary>
        /// Id Evento
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public int IdEvent { get; set; }

    }
}
