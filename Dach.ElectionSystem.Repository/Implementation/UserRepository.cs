using Dach.ElectionSystem.Models.Persitence;
using Dach.ElectionSystem.Repository.DBContext;
using Dach.ElectionSystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Repository.Implementation
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly WebApiDbContext context;

        public UserRepository(WebApiDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<User> GetUserByUsernameOrEmailAndPassword(string username, string password)
        {
            var user =  context.User.FirstOrDefault(user => (user.UserName == username || user.Email == username)
                                                             && user.Password == password);
            return await Task.Run(()=>user);
        }
        public async Task<User> GetUserByUsernameAndEmail(string username, string email)
        {
            var user = context.User.FirstOrDefault(user => (user.UserName == username || user.Email == email));
            return await Task.Run(() => user);
        }
        public async Task<User> GetUserByUsernameByEmail(string email)
        {
            var user = context.User.Include(u=>u.ListEventAdministrator).
            FirstOrDefault(user => user.Email == email);
            return await Task.Run(() => user);
        }
        public async Task<User> GetUserByUsernameByUsername(string username)
        {
            var user = context.User.FirstOrDefault(user => (user.UserName == username));
            return await Task.Run(() => user);
        }
    }
}
