using AutoMapper;
using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Response.Candidate;
using Dach.ElectionSystem.Utils.Mapper.Event;
using Dach.ElectionSystem.Utils.Mapper.User;

namespace Dach.ElectionSystem.Utils.Mapper
{
    public class CustomMapperDTO : Profile
    {
        public CustomMapperDTO()
        {
            //Mappers to Candidate
            CreateMap<CandidateCreateRequest, Candidate>();
            CreateMap<Candidate, CandidateCreateResponse>();
            this.ConfigEventMapper();
            this.ConfigUserMapper();
        }
    }
}
