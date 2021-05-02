using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Repository.UnitOfWork;
namespace Dach.ElectionSystem.Repository.Implementation
{
    public class EventAdministratorRepository : GenericRepository<EventAdministrator>, IEventAdministratorRepository
    {
        #region Constructor
        public EventAdministratorRepository(IUnitOfWork unitOfWork) : base(unitOfWork){}
        #endregion

 

    }
}
