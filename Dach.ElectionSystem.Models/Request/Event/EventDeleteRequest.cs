using Dach.ElectionSystem.Models.RequestBase;
using Dach.ElectionSystem.Models.Response.Event;
using MediatR;
namespace Dach.ElectionSystem.Models.Request.Event
{
    /// <summary>
    /// Clase EventDeleteRequest
    /// </summary>
     public class EventDeleteRequest : RequestBaseImpl, IRequest<EventDeleteResponse>
    {
         /// <summary>
        /// Id de Evento
        /// </summary>
        public int Id { get; set; }

    }
}
