using System;
using Dach.ElectionSystem.Repository.DBContext;
using Dach.ElectionSystem.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Dach.ElectionSystem.Repository.UnitOfWork
{
    public class ElectionUnitOfWork : UnitOfWork, IElectionUnitOfWork
    {
        private readonly IServiceProvider _serviceProvider;

        public ElectionUnitOfWork(IServiceProvider serviceProvider, WebApiDbContext context):base(context) 
        {
            _serviceProvider = serviceProvider;
        }
        public ICandidateRepository GetCandidateRepository()
         => _serviceProvider.GetService<ICandidateRepository>();

        public IEventAdministratorRepository GetEventAdministratorRepository()
         => _serviceProvider.GetService<IEventAdministratorRepository>();

        public IEventRepository GetEventRepository()
         => _serviceProvider.GetService<IEventRepository>();

        public IUserRepository GetUserRepository()
         => _serviceProvider.GetService<IUserRepository>();

        public IVoteRegisterEmailRepository GetVoteRegisterEmailRepository()
         => _serviceProvider.GetService<IVoteRegisterEmailRepository>();
         
        public IVoteRepository GetVoteRepository() 
        => _serviceProvider.GetService<IVoteRepository>();
    }
}