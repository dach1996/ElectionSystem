using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int Id);
        Task<IEnumerable<T>> GetAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> whereCondition,
                           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                           string includeProperties = "");
        Task<IEnumerable<T>> GetAsyncInclude(Expression<Func<T, bool>> whereCondition = null,
                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                            Expression<Func<T, string>> includeProperties  = null);
        Task<bool> CreateAsync(T entity);
        Task<bool> CreateManyAsync(IEnumerable<T> entity);
        Task<bool> DeleteByIdAsync(int Id);
        Task<bool> Update(T entity);
        Task<IQueryable<T>> GetQueryAsync(Expression<Func<T, bool>> whereCondition = null,
                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                  string includeProperties = "");
    }
}
