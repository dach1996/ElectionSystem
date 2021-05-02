using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Dach.ElectionSystem.Utils.Mediator
{
    public static class MediatorVote
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddIMediaRVoteConfig(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new System.ArgumentNullException(nameof(services));
            }
        }
    }
}