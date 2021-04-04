using AutoMapper;
using Dach.ElectionSystem.Utils.Mapper.Event;
using Dach.ElectionSystem.Utils.Mapper.Group;
using Dach.ElectionSystem.Utils.Mapper.User;
using Dach.ElectionSystem.Utils.Mapper.Candidate;
using Dach.ElectionSystem.Utils.Mapper.Vote;

namespace Dach.ElectionSystem.Utils.Mapper
{
    public class CustomMapperDTO : Profile
    {
        public CustomMapperDTO()
        {
            //Mappers to Candidate

            this.ConfigEventMapper();
            this.ConfigUserMapper();
            this.ConfigGroupMapper();
            this.ConfigCandidateMapper();
            this.ConfigVoteMapper();
        }
    }
}
