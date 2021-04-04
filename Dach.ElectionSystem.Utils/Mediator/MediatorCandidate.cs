using Dach.ElectionSystem.BusinessLogic.Candidate;
using Dach.ElectionSystem.Models.Request.Candidate;
using Dach.ElectionSystem.Models.Response.Candidate;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Dach.ElectionSystem.Utils.Mediator
{
    public static class MediatorCandidate
    {

        public static void AddIMediaRCandidateConfig(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CandidateCreateRequest, CandidateCreateResponse>, CandidateCreateHandler>();
            services.AddTransient<IRequestHandler<CandidateUpdateRequest, CandidateUpdateResponse>, CandidateUpdateHandler>();
            services.AddTransient<IRequestHandler<CandidateDeleteRequest, CandidateDeleteResponse>, CandidateDeleteHandler>();
            services.AddTransient<IRequestHandler<CandidateGetRequest, CandidateGetResponse>, CandidateGetHandler>();
        }

    }
}