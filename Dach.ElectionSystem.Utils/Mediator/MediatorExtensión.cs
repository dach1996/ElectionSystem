using Dach.ElectionSystem.BusinessLogic.Auth;
using Dach.ElectionSystem.BusinessLogic.Candidate;
using Dach.ElectionSystem.BusinessLogic.Event;
using Dach.ElectionSystem.BusinessLogic.User;
using Dach.ElectionSystem.Models.Auth;
using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Request.Event;
using Dach.ElectionSystem.Models.Request.User;
using Dach.ElectionSystem.Models.Response.Auth;
using Dach.ElectionSystem.Models.Response.Candidate;
using Dach.ElectionSystem.Models.Response.Event;
using Dach.ElectionSystem.Models.Response.User;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Utils.Mediator
{
    public static class MediatorExtensión
    {
        public static void AddIMediaRServices(this IServiceCollection services)
        {

            //IMediator Login
            services.AddTransient<IRequestHandler<LoginRequest, LoginResponse>, AuthHandler>();

            //IMediator Event
            services.AddTransient<IRequestHandler<EventCreateRequest, EventCreateResponse>, EventCreateHandler>();
            services.AddTransient<IRequestHandler<EventDeleteRequest, EventDeleteResponse>, EventDeleteHandler>();

            //Mediator Candidate
            services.AddTransient<IRequestHandler<CandidateCreateRequest, CandidateCreateResponse>, CandidateCreateHandler>();
           
            MediatorUser.AddIMediaRUserConfig(services);
        }
    }
}
