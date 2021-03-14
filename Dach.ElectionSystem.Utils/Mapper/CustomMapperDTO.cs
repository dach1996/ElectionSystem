using AutoMapper;
using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Models.Response.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Utils.Mapper
{
    public class CustomMapperDTO : Profile
    {
        public CustomMapperDTO()
        {
            ///Mappers to Event
            CreateMap<EventCreateRequest, Event>();
            CreateMap<Event, EventCreateResponse>();
        }
    }
}
