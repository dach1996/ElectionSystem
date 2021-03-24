using Dach.ElectionSystem.Models.Persitence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByUsernameOrEmailAndPassword(string username, string password);
        Task<User> GetUserByUsernameAndEmail(string username, string email);
    }
}
