using CRUD.DataAccess.Data;
using CRUD.DataAccess.Repository.IRepository;
using CRUD.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DataAccess.Repository
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        private readonly ApplicationDbContext _db;

        public BrandRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task Update(Brand brand)
        {
            var brandItem = await _db.Brand.FirstOrDefaultAsync(x => x.Id == brand.Id);
            if(brandItem != null)
            {
                brandItem.Name = brand.Name;
                brandItem.Status = brand.Status;
            }
        }
    }
}
