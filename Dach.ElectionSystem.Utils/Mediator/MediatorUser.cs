using Dach.ElectionSystem.BusinessLogic.User;
using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Models.Response.User;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Dach.ElectionSystem.Utils.Mediator
{
    public static class MediatorUser
    {
           public static void AddIMediaRUserConfig(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<UserCreateRequest, UserCreateResponse>, UserCreateHandler>();
            services.AddTransient<IRequestHandler<UserUpdateRequest, UserUpdateResponse>, UserUpdateHandler>();
            services.AddTransient<IRequestHandler<UserGetRequest, UserGetResponse>, UserGetHandler>();
        }
    }
}