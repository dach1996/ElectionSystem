using Dach.ElectionSystem.Models.Response.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Models.Request.Event
{
     public class EventCreateRequest : IRequest<EventCreateResponse>
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool MaxPeople { get; set; }
        public int NumberMaxPeople { get; set; }
        public int NumberMaxCandidate { get; set; }
        public string Category { get; set; }
    }
}
