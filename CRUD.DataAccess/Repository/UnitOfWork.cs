using CRUD.DataAccess.Data;
using CRUD.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DataAccess.Repository
{
    public  class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Brand = new BrandRepository(_db);
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
        }

        public IBrandRepository Brand { get; private set; }

        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task  SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
