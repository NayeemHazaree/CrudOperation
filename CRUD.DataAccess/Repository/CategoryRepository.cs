using CRUD.DataAccess.Data;
using CRUD.DataAccess.Repository.IRepository;
using CRUD.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task Update(Category obj)
        {
            var CatFromDb = await _db.Category.FirstOrDefaultAsync(x => x.Id == obj.Id);
            if(CatFromDb != null)
            {
                CatFromDb.Name = obj.Name;
                CatFromDb.Status = obj.Status;
            }
        }
    }
}
