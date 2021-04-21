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
    public class EventAdministratorRepository : GenericRepository<EventAdministrator>, IEventAdministratorRepository
    {
        #region Constructor
        private readonly IUnitOfWork unitOfWork;
        public EventAdministratorRepository(IUnitOfWork unitOfWork) : base(unitOfWork) =>
            this.unitOfWork = unitOfWork;
        #endregion

 

    }
}
