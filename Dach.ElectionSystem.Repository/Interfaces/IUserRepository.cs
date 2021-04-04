using Dach.ElectionSystem.Models.Persitence;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByUsernameOrEmailAndPassword(string username, string password);
        Task<User> GetUserByUsernameAndEmail(string username, string email);
        Task<User> GetUserByUsernameByEmail(string email);
        Task<User> GetUserByUsernameByUsername(string username);
    }
}
