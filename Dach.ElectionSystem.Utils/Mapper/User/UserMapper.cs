using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Models.Response.User;

namespace Dach.ElectionSystem.Utils.Mapper.User
{
    public static class UserMapper
    {
        public static void ConfigUserMapper(this CustomMapperDto profile)
        {
            //Mapper to User - User Create
             profile.CreateMap<UserCreateRequest, Models.Persitence.User>();
            profile.CreateMap<Models.Persitence.User, UserCreateResponse>();

            //Mapper to User - User Update
            profile.CreateMap<UserUpdateRequest, Models.Persitence.User>();
            profile.CreateMap<Models.Persitence.User, UserUpdateResponse>();

            //Mapper to User - Get Update
            profile.CreateMap<Models.Persitence.User, UserBaseResponse>();
        }

    }
}
