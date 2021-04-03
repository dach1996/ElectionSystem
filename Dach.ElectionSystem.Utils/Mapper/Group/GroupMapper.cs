using Dach.ElectionSystem.Models.Request.Group;
using Dach.ElectionSystem.Models.Response.Group;

namespace Dach.ElectionSystem.Utils.Mapper.Group
{
    public static class GroupMapper
    {
            public static void ConfigGroupMapper(this CustomMapperDTO profile)
        {
            //Create
            profile.CreateMap<GroupCreateRequest, Models.Persitence.Group>();
            profile.CreateMap<Models.Persitence.Group, GroupCreateResponse>();

            //Delete
            profile.CreateMap<GroupDeleteRequest, Models.Persitence.Group>();
            profile.CreateMap<Models.Persitence.Group, GroupDeleteResponse>();

            //Update
            profile.CreateMap<GroupUpdateRequest, Models.Persitence.Group>();
            profile.CreateMap<Models.Persitence.Group, GroupUpdateResponse>();

              //Get
            profile.CreateMap<GroupGetRequest, Models.Persitence.Group>();
            profile.CreateMap<Models.Persitence.Group, GroupBaseResponse>();
        }
    }
}