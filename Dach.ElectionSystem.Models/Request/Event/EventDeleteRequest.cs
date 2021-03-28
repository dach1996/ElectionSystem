using Dach.ElectionSystem.Models.Response.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Models.Request.Event
{
    /// <summary>
    /// Clase EventDeleteRequest
    /// </summary>
     public class EventDeleteRequest : IRequest<EventDeleteResponse>
    {
        /// <summary>
        /// Id de evento
        /// </summary>
        /// <value></value>
        public int IdEvent { get; set; }
    }
}
