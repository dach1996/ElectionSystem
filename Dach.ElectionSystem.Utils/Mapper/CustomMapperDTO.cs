using AutoMapper;
using Dach.ElectionSystem.Utils.Mapper.Event;
using Dach.ElectionSystem.Utils.Mapper.User;
using Dach.ElectionSystem.Utils.Mapper.Candidate;
using Dach.ElectionSystem.Utils.Mapper.Vote;
using Dach.ElectionSystem.Utils.Mapper.EventAdministrator;

namespace Dach.ElectionSystem.Utils.Mapper
{
    public class CustomMapperDto : Profile
    {
        public CustomMapperDto()
        {
            //Mappers to Candidate

            this.ConfigEventMapper();
            this.ConfigUserMapper();
            this.ConfigCandidateMapper();
            this.ConfigVoteMapper();
            this.ConfigEventAdministratorMapper();
        }
    }
}
