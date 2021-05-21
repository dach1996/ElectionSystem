using Dach.ElectionSystem.Repository.Interfaces;

namespace Dach.ElectionSystem.Repository.UnitOfWork
{
    public interface IElectionUnitOfWork : IUnitOfWork
    {
           public IUserRepository GetUserRepository();
           public IEventRepository GetEventRepository();
           public IEventAdministratorRepository GetEventAdministratorRepository();
           public ICandidateRepository GetCandidateRepository();
           public IVoteRepository GetVoteRepository();
           public IVoteRegisterEmailRepository GetVoteRegisterEmailRepository();
    }
}