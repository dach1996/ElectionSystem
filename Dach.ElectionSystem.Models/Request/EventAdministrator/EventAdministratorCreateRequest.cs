
using System.Text.Json.Serialization;
using Dach.ElectionSystem.Models.Response.EventAdministrator;
using MediatR;
namespace Dach.ElectionSystem.Models.Request.EventAdministrator
{
    /// <summary>
    /// Clase EventAdministratorCreateRequest
    /// </summary>
    public class EventAdministratorCreateRequest : EventAdministratorBaseRequest, IRequest<EventAdministratorCreateResponse>
    {
  
    }
}
