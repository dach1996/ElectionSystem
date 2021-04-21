using Dach.ElectionSystem.Models.Persitence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace Dach.ElectionSystem.Repository.DBContext
{
    public class WebApiDbContext : DbContext
    {
        #region Constructor
        private readonly ILogger<WebApiDbContext> logger;
           public WebApiDbContext(DbContextOptions<WebApiDbContext> options,ILogger<WebApiDbContext> logger) : base(options)
        {
            this.logger = logger;
        }
        #endregion
        
        #region DbSets
        public DbSet<User> User { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Vote> Vote { get; set; }
        public DbSet<EventAdministrator> EventAdministrator { get; set; }
        #endregion
    }
}
