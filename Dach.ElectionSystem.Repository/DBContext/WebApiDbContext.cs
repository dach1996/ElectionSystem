using Dach.ElectionSystem.Models.Persitence;
using Microsoft.EntityFrameworkCore;
namespace Dach.ElectionSystem.Repository.DBContext
{
    public class WebApiDbContext : DbContext
    {
        #region Constructor
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options)
        {
        }
        #endregion

        #region DbSets
        public DbSet<User> User { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Vote> Vote { get; set; }
        public DbSet<EventAdministrator> EventAdministrator { get; set; }
        public DbSet<EventNumber> EventNumber { get; set; }
        public DbSet<VoteRegisterEmail> VoteRegisterEmail { get; set; }
        public DbSet<CandidateImage> CandidateImages { get; set; }
        #endregion
    }
}
