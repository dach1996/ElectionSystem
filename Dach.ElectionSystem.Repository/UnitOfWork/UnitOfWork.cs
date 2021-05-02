using System;
using Dach.ElectionSystem.Repository.DBContext;
namespace Dach.ElectionSystem.Repository.UnitOfWork
{ 
    public class UnitOfWork : IUnitOfWork
    {
        public WebApiDbContext Context { get; set; }
        
        public UnitOfWork(WebApiDbContext context)
        {
            Context = context;
        }
        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
