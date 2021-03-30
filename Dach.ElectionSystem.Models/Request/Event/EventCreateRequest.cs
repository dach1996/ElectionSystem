using System.Globalization;
using Dach.ElectionSystem.Models.Response.Event;
using MediatR;
namespace Dach.ElectionSystem.Models.Request.Event
{
    /// <summary>
    /// Clase EventCreateRequest
    /// </summary>
     public class EventCreateRequest : EventBaseRequest,  IRequest<EventCreateResponse>
    {
        
    }
}
