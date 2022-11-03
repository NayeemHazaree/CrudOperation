using CRUD.DataAccess.Data;
using CRUD.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task<T> Find(Guid? id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool isTracking = true)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var incldProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incldProp);
                }
            }


            if (!isTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeProperties = null, bool isTracking = true)
        {
            IQueryable<T> query = dbSet;
            if(filter != null)
            {
                query = query.Where(filter);
            }

            if(includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }

            if(orderBy != null)
            {
                query = orderBy(query);
            }

            if (!isTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        public async Task Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
