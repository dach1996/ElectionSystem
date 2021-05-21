using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Repository.DBContext;
using Dach.ElectionSystem.Repository.Interfaces;


namespace Dach.ElectionSystem.Repository.Implementation
{
    public class VoteRepository : GenericRepository<Vote>, IVoteRepository
    {
        public VoteRepository(WebApiDbContext context) : base(context)
        {
        }
    }
}