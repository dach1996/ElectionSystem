using Dach.ElectionSystem.Repository.Interfaces;
using Dach.ElectionSystem.Repository.UnitOfWork;
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
        private readonly IUnitOfWork _unitOfWork;
        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _unitOfWork.Context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> whereCondition,
                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                  string includeProperties = "")
        {
            IQueryable<T> query = _unitOfWork.Context.Set<T>();

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
            IQueryable<T> query = _unitOfWork.Context.Set<T>();

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

            var save = await _unitOfWork.Context.Set<T>().AddAsync(entity);

            if (save != null)
                created = true;
            _unitOfWork.Context.SaveChanges();

            return created;
        }

        public async Task<bool> Update(T entity)
        {

            bool update = false;

            var save = _unitOfWork.Context.Set<T>().Update(entity);

            if (save != null)
                update = true;
            _unitOfWork.Context.SaveChanges();
            return await Task.Run<bool>(() => update);
        }

        public async Task<bool> DeleteByIdAsync(int Id)
        {
            bool remove = false;
            var getEntity = await this.GetByIdAsync(Id);

                var save = _unitOfWork.Context.Set<T>().Remove(getEntity);

                if (save != null)
                    remove = true;
                _unitOfWork.Context.SaveChanges();

            return remove;
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _unitOfWork.Context.Set<T>().FindAsync(Id);
        }

        public async Task<IEnumerable<T>> GetAsyncInclude(Expression<Func<T, bool>> whereCondition = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Expression<Func<T, string>> includeProperties = null)
        {


            IQueryable<T> query = _unitOfWork.Context.Set<T>();

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
            await _unitOfWork.Context.Set<T>().AddRangeAsync(entity);
            var created = true;
            _unitOfWork.Context.SaveChanges();
            return created;
        }
    }
}
