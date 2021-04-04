using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Repository.UnitOfWork;

namespace Dach.ElectionSystem.Repository.Implementation
{
    public class VoteRepository : GenericRepository<Vote>, IVoteRepository
    {
        public VoteRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}