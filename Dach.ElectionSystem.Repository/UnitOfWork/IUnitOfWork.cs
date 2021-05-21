using System;
using System.Data;
using Dach.ElectionSystem.Repository.DBContext;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Dach.ElectionSystem.Repository.UnitOfWork
{ 
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollBackAsync();
        WebApiDbContext Context { get; }
        IDbContextTransaction Transaction{get;set;}
    }
}
