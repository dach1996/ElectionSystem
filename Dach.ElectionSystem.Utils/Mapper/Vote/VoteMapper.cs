
using Dach.ElectionSystem.Models.Request.Vote;
using Dach.ElectionSystem.Models.Response.Vote;

namespace Dach.ElectionSystem.Utils.Mapper.Vote
{
    public static class VoteMapper
    {
        public static void ConfigVoteMapper(this CustomMapperDTO profile)
        {
              profile.CreateMap<VoteCreateRequest, Models.Persitence.Vote>();
            profile.CreateMap<Models.Persitence.Vote, VoteCreateResponse>();

            //Delete
            profile.CreateMap<VoteDeleteRequest, Models.Persitence.Vote>();
            profile.CreateMap<Models.Persitence.Vote, VoteDeleteResponse>();

            //Update
            profile.CreateMap<VoteUpdateRequest, Models.Persitence.Vote>();
            profile.CreateMap<Models.Persitence.Vote, VoteUpdateResponse>();

              //Get
            profile.CreateMap<VoteGetRequest, Models.Persitence.Vote>();
            profile.CreateMap<Models.Persitence.Vote, VoteResponseBase>();

        }

    }
}
