using AutoMapper;
using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Models.Response.Candidate;
using Dach.ElectionSystem.Models.Response.Event;
using Dach.ElectionSystem.Models.Response.User;
using Dach.ElectionSystem.Utils.Extension;
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

            //Mapper to User - User Create
            CreateMap<UserCreateRequest, User>()
                .ForMember(
                destino=>destino.Rol,
                origen=> origen.MapFrom(u=>(int)u.Role))
                .ForMember(
                destino => destino.RolName,
                origen => origen.MapFrom(u =>u.Role.ToString())
                );
            CreateMap<User, UserCreateResponse>()
                .ForMember(
                destino => destino.Role,
                origen => origen.MapFrom(u => u.Rol));
        }
    }
}
