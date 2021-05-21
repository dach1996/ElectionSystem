using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Repository.DBContext;
using Dach.ElectionSystem.Repository.Interfaces;
namespace Dach.ElectionSystem.Repository.Implementation
{
    public class CandidateRepository : GenericRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(WebApiDbContext context) : base(context){}
    
    }
}
