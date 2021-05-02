using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Models.Response.Event;

namespace Dach.ElectionSystem.Utils.Mapper.Event
{
    public static class EventMapper
    {
        public static void ConfigEventMapper(this CustomMapperDto profile)
        {
            //Create
            profile.CreateMap<EventCreateRequest, Models.Persitence.Event>();
            profile.CreateMap<Models.Persitence.Event, EventCreateResponse>();

            //Delete
            profile.CreateMap<EventDeleteRequest, Models.Persitence.Event>();
            profile.CreateMap<Models.Persitence.Event, EventDeleteResponse>();

            //Update
            profile.CreateMap<EventUpdateRequest, Models.Persitence.Event>();
            profile.CreateMap<Models.Persitence.Event, EventUpdateResponse>();

              //Get
            profile.CreateMap<EventGetRequest, Models.Persitence.Event>();
            profile.CreateMap<Models.Persitence.Event, EventResponseBase>();
        }
    }
}