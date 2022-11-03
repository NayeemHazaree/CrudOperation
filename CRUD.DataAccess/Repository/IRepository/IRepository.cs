using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> Find(Guid? id);

        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>,IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null,
            bool isTracking = true
            );

         Task<T> FirstOrDefaultAsync(
            Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null,
            bool isTracking = true
            );

        Task AddAsync(T entity);

        Task Remove(T entity);

        Task SaveAsync();

    }
}
