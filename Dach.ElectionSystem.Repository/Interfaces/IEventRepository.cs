using Dach.ElectionSystem.Models.Persitence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Repository.Interfaces
{
    public interface IEventRepository : IGenericRepository<Event>
    {
    Task<IEnumerable<Event>> GetEventsWithAdministratorAsync( Expression<Func<Event, bool>> whereCondition = null, Func<IQueryable<Event>, 
                                                            IOrderedQueryable<Event>> orderBy = null,
                                                        string includeProperties = "");
    }
}
