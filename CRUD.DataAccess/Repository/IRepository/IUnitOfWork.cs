using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        public IBrandRepository Brand { get; }
        public ICategoryRepository Category { get; }
        public IProductRepository Product { get; }
        Task SaveAsync();
    }
}
