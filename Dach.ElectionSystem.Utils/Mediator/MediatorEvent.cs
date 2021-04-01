using Dach.ElectionSystem.BusinessLogic.Event;
using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Models.Response.Event;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Dach.ElectionSystem.Utils.Mediator
{
    public static class MediatorEvent
    {
           public static void AddIMediaREventConfig(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<EventCreateRequest, EventCreateResponse>, EventCreateHandler>();
            services.AddTransient<IRequestHandler<EventDeleteRequest, EventDeleteResponse>, EventDeleteHandler>();
            services.AddTransient<IRequestHandler<EventUpdateRequest, EventUpdateResponse>, EventUpdateHandler>();
        }
    }
}