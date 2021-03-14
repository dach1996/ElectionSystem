using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Repository.Implementation
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
