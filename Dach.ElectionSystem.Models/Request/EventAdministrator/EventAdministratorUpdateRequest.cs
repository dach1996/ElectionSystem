using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.Response.EventAdministrator;
using MediatR;

namespace Dach.ElectionSystem.Models.Request.EventAdministrator
{
    /// <summary>
    /// Clase EventAdministratorUpdateRequest
    /// </summary>
    public class EventAdministratorUpdateRequest : EventAdministratorBaseRequest, IRequest<EventAdministratorUpdateResponse>
    {
        /// <summary>
        /// EventAdministratoro Activo
        /// </summary>
        public bool IsActive { get; set; }
    }
}