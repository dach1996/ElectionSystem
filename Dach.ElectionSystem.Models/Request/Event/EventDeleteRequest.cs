using Dach.ElectionSystem.Models.Response.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Models.Request.Event
{
     public class EventDeleteRequest : IRequest<EventDeleteResponse>
    {
        public int IdEvent { get; set; }
    }
}
