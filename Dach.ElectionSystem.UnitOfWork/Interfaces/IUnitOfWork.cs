using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.UnitOfWork.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
