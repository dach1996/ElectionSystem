using Dach.ElectionSystem.Repository.DBContext;
using Dach.ElectionSystem.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dach.ElectionSystem.Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class

    {
        private readonly WebApiDbContext _context;
        public GenericRepository(WebApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> whereCondition,
                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                  string includeProperties = "")
        {
            IQueryable<T> query = _context.Set<T>();

            if (whereCondition != null)
            {
                query = query.Where(whereCondition);
            }
            foreach (var includeProperty in includeProperties.Split
         (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<IQueryable<T>> GetQueryAsync(Expression<Func<T, bool>> whereCondition = null,
                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                  string includeProperties = "")
        {
            IQueryable<T> query = _context.Set<T>();

            if (whereCondition != null)
            {
                query = query.Where(whereCondition);
            }
            foreach (var includeProperty in includeProperties.Split
         (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                _ = orderBy(query);
            }
            return await Task.Run<IQueryable<T>>(() => query);
        }

        public async Task<bool> CreateAsync(T entity)
        {

            bool created = false;

            var save = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            if (save != null)
                created = true;

            return created;
        }

        public async Task<bool> Update(T entity)
        {

            bool update = false;

            var save = _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            if (save != null)
                update = true;
            return await Task.Run<bool>(() => update);
        }

        public async Task<bool> DeleteByIdAsync(int Id)
        {
            bool remove = false;
            var getEntity = await this.GetByIdAsync(Id);
            var save = _context.Set<T>().Remove(getEntity);
            await _context.SaveChangesAsync();
            if (save != null)
                remove = true;

            return remove;
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public async Task<IEnumerable<T>> GetAsyncInclude(Expression<Func<T, bool>> whereCondition = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Expression<Func<T, string>> includeProperties = null)
        {


            IQueryable<T> query = _context.Set<T>();

            if (whereCondition != null)
            {
                query = query.Where(whereCondition);
            }


            if (includeProperties != null)
            {
                var propertys = includeProperties.Body.ToString().Replace("\\", "").Replace("\"", "");
                foreach (var includeProperty in propertys.Split
                 (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<bool> CreateManyAsync(IEnumerable<T> entity)
        {
            await _context.Set<T>().AddRangeAsync(entity);
            await _context.SaveChangesAsync();
            var created = true;
            return created;
        }
    }
}
