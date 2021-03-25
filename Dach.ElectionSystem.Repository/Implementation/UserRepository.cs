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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<User> GetUserByUsernameOrEmailAndPassword(string username, string password)
        {
            var user =  unitOfWork.Context.User.FirstOrDefault(user => (user.UserName == username || user.Email == username)
                                                             && user.Password == password);
            return await Task.Run(()=>user);
        }
        public async Task<User> GetUserByUsernameAndEmail(string username, string email)
        {
            var user = unitOfWork.Context.User.FirstOrDefault(user => (user.UserName == username || user.Email == email));
            return await Task.Run(() => user);
        }
        public async Task<User> GetUserByUsernameByEmail(string email)
        {
            var user = unitOfWork.Context.User.FirstOrDefault(user => (user.Email == email));
            return await Task.Run(() => user);
        }
        public async Task<User> GetUserByUsernameByUsername(string username)
        {
            var user = unitOfWork.Context.User.FirstOrDefault(user => (user.UserName == username));
            return await Task.Run(() => user);
        }
    }
}
