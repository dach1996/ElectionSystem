using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Repository.DBContext;
using Dach.ElectionSystem.Repository.Interfaces;
namespace Dach.ElectionSystem.Repository.Implementation
{
    public class EventAdministratorRepository : GenericRepository<EventAdministrator>, IEventAdministratorRepository
    {
        #region Constructor
        public EventAdministratorRepository(WebApiDbContext context) : base(context){}
        #endregion

 

    }
}
