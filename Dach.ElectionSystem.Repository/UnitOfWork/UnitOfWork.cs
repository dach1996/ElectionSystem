using Dach.ElectionSystem.Repository.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Repository.UnitOfWork
{ 
    public class UnitOfWork : IUnitOfWork
    {
        public WebApiDbContext Context { get; set; }
        
        public UnitOfWork(WebApiDbContext context)
        {
            Context = context;
        }
        public void Dispose()
        {
            Context.Dispose();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
