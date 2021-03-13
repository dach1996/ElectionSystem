using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Repository.UnitOfWork;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Repository.Implementation
{
    public class UserRepository : GenericRepository<User>, IUsuarioRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork) {}
    }
}
