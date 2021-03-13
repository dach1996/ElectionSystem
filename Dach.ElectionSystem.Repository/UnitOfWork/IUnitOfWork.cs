using Dach.ElectionSystem.Repository.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Repository.UnitOfWork
{ 
    public interface IUnitOfWork : IDisposable
    {
        WebApiDbContext Context { get; }
        void SaveChanges();
    }
}
