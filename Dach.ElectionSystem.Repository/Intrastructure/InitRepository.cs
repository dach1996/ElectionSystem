
using Dach.ElectionSystem.Repository.Implementation;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Repository.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Repository.Intrastructure
{
    public static class InitRepository
    {
        public static void AddSingletonRepository(this IServiceCollection services) {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }
    }
}
