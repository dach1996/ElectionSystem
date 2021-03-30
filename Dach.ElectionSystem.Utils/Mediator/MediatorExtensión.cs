using Dach.ElectionSystem.BusinessLogic.Auth;
using Dach.ElectionSystem.BusinessLogic.Candidate;
using Dach.ElectionSystem.Models.Auth;
using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Response.Auth;
using Dach.ElectionSystem.Models.Response.Candidate;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Dach.ElectionSystem.Utils.Mediator
{
    public static class MediatorExtensión
    {
        public static void AddIMediaRServices(this IServiceCollection services)
        {

            //IMediator Login
            services.AddTransient<IRequestHandler<LoginRequest, LoginResponse>, AuthHandler>();
    
            //Mediator Candidate
            services.AddTransient<IRequestHandler<CandidateCreateRequest, CandidateCreateResponse>, CandidateCreateHandler>();
           
            MediatorUser.AddIMediaRUserConfig(services);
            MediatorEvent.AddIMediaREventConfig(services);
        }
    }
}
