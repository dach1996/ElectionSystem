using System;
using System.Threading.Tasks;
using Dach.ElectionSystem.Repository.DBContext;
using Microsoft.EntityFrameworkCore.Storage;
namespace Dach.ElectionSystem.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public WebApiDbContext Context { get; set; }

        public UnitOfWork(WebApiDbContext context)
        {
            Context = context;
        }

        public IDbContextTransaction Transaction { get; set; }

        
        public async Task BeginTransactionAsync()
        {
            if (Transaction == null)
                Transaction = await Context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (Transaction != null)
            {
                await Context.SaveChangesAsync();
                await Context.Database.CommitTransactionAsync().ConfigureAwait(false);
                Transaction = null;
            }
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Transaction?.Dispose();
            Context?.Dispose();
        }

        public async Task RollBackAsync()
        {
            if (Transaction != null)
            {
                await Context.Database.RollbackTransactionAsync().ConfigureAwait(false);
                Transaction = null;
            }
        }
    }
}
