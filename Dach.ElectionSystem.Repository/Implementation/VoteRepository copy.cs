using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Repository.UnitOfWork;

namespace Dach.ElectionSystem.Repository.Implementation
{
    public class VoteRegisterEmailRepository : GenericRepository<VoteRegisterEmail>, IVoteRegisterEmailRepository
    {
        public VoteRegisterEmailRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}