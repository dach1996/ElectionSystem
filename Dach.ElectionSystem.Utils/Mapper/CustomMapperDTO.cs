using AutoMapper;
using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Models.Response.Candidate;
using Dach.ElectionSystem.Models.Response.Event;
using Dach.ElectionSystem.Models.Response.User;

namespace Dach.ElectionSystem.Utils.Mapper
{
    public class CustomMapperDTO : Profile
    {
        public CustomMapperDTO()
        {
            //Mappers to Event
            CreateMap<EventCreateRequest, Event>();
            CreateMap<Event, EventCreateResponse>();

            //Mappers to Candidate
            CreateMap<CandidateCreateRequest, Candidate>();
            CreateMap<Candidate, CandidateCreateResponse>();

            //Mapper to User
            CreateMap<UserCreateRequest, User>();
            CreateMap<User, UserCreateResponse>();
        }
    }
}
