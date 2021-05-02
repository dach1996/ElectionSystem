using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Dach.ElectionSystem.Repository.Implementation
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        #region Constructor
        public EventRepository(IUnitOfWork unitOfWork) : base(unitOfWork){}
        #endregion

        public async Task<IEnumerable<Event>> GetEventsWithAdministratorAsync(Expression<Func<Event, bool>> whereCondition = null, Func<IQueryable<Event>,
         IOrderedQueryable<Event>> orderBy = null,
         string includeProperties = ""   )    
        {
            var query = await this.GetQueryAsync(whereCondition, orderBy, includeProperties);
            return await query.Include(e=>e.ListEventAdministrator).ToListAsync();
        }

    }
}
