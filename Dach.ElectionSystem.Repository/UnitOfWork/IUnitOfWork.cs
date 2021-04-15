using Dach.ElectionSystem.Repository.DBContext;
using System;
namespace Dach.ElectionSystem.Repository.UnitOfWork
{ 
    public interface IUnitOfWork : IDisposable
    {
        WebApiDbContext Context { get; }
        void SaveChanges();
    }
}
