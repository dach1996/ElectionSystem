using Dach.ElectionSystem.Models.Request.EventAdministrator;
using Dach.ElectionSystem.Models.Response.EventAdministrator;

namespace Dach.ElectionSystem.Utils.Mapper.EventAdministrator
{
    public static class EventAdministratorMapper
    {
        public static void ConfigEventAdministratorMapper(this CustomMapperDto profile)
        {
            //Create
            profile.CreateMap<EventAdministratorCreateRequest, Models.Persitence.EventAdministrator>();
            profile.CreateMap<Models.Persitence.EventAdministrator, EventAdministratorCreateResponse>();

            //Delete
            profile.CreateMap<EventAdministratorDesactiveRequest, Models.Persitence.EventAdministrator>();
            profile.CreateMap<Models.Persitence.EventAdministrator, EventAdministratorDesactiveResponse>();

            //Update
            profile.CreateMap<EventAdministratorUpdateRequest, Models.Persitence.EventAdministrator>();
            profile.CreateMap<Models.Persitence.EventAdministrator, EventAdministratorUpdateResponse>();

              //Get
            profile.CreateMap<EventAdministratorGetRequest, Models.Persitence.EventAdministrator>();
            profile.CreateMap<Models.Persitence.EventAdministrator, EventAdministratorBaseResponse>();
        }
    }
}