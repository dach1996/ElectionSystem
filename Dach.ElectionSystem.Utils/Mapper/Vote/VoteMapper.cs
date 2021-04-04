
namespace Dach.ElectionSystem.Utils.Mapper.Vote
{
    public static class VoteMapper
    {
        public static void ConfigVoteMapper(this CustomMapperDTO profile)
        {
            //Mapper to Vote - Vote Create
            /*profile.CreateMap<VoteCreateRequest, Models.Persitence.Vote>()
                .ForMember(
                destino => destino.Rol,
                origen => origen.MapFrom(u => (int)u.Role))
                .ForMember(
                destino => destino.RolName,
                origen => origen.MapFrom(u => u.Role.ToString())
                );*/
           /* profile.CreateMap<VoteCreateRequest, Models.Persitence.Vote>();
            profile.CreateMap<Models.Persitence.Vote, VoteCreateResponse>();

            //Mapper to Vote - Vote Update
            profile.CreateMap<VoteUpdateRequest, Models.Persitence.Vote>();
            profile.CreateMap<Models.Persitence.Vote, VoteUpdateResponse>();

            //Mapper to Vote Delete
            profile.CreateMap<Models.Persitence.Vote, VoteDeleteResponse>();
            //Mapper to Vote - Get Update

            profile.CreateMap<Models.Persitence.Vote, VoteResponseBase>();*/

        }

    }
}
