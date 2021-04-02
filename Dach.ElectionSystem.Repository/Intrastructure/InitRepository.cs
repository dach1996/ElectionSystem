using Dach.ElectionSystem.Repository.Implementation;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Repository.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
namespace Dach.ElectionSystem.Repository.Intrastructure
{
    public static class InitRepository
    {
        public static void AddRepositorys(this IServiceCollection services) {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<ICandidateRepository, CandidateRepository>();
            //Unit work
            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }
    }
}
