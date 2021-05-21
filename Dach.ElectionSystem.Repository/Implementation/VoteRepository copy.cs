using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Repository.DBContext;
using Dach.ElectionSystem.Repository.Interfaces;

namespace Dach.ElectionSystem.Repository.Implementation
{
    public class VoteRegisterEmailRepository : GenericRepository<VoteRegisterEmail>, IVoteRegisterEmailRepository
    {
        public VoteRegisterEmailRepository(WebApiDbContext context) : base(context)
        {
        }
    }
}