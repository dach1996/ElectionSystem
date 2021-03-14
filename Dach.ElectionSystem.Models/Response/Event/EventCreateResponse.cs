using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Models.Response.Event
{
    public class EventCreateResponse 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool MaxPeople { get; set; }
        public int NumberMaxPeople { get; set; }
        public int NumberMaxCandidate { get; set; }
        public string Category { get; set; }
    }
}
