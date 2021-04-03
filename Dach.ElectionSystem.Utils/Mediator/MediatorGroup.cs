using Dach.ElectionSystem.BusinessLogic.Group;
using Dach.ElectionSystem.Models.Request.Group;
using Dach.ElectionSystem.Models.Response.Group;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Dach.ElectionSystem.Utils.Mediator
{
    public static class MediatorGroup
    {
             public static void AddIMediaRGroupConfig(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<GroupCreateRequest, GroupCreateResponse>, GroupCreateHandler>();
            services.AddTransient<IRequestHandler<GroupUpdateRequest, GroupUpdateResponse>, GroupUpdateHandler>();
            services.AddTransient<IRequestHandler<GroupDeleteRequest, GroupDeleteResponse>, GroupDeleteHandler>();
            services.AddTransient<IRequestHandler<GroupGetRequest, GroupGetResponse>, GroupGetHandler>();
        }
    }
}