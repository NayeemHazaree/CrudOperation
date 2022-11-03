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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<SelectListItem>> DropDownList(string obj)
        {
            if(obj == "Category")
            {
                return _db.Category.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            }
            if(obj == "Brand")
            {
                return _db.Brand.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            }
            return await Task.FromResult<IEnumerable<SelectListItem>>(null);
        }

        public async Task Update(Product product)
        {
            var proditem = await  _db.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
            if(proditem != null)
            {
                proditem.Name = product.Name;
                proditem.Description = product.Description;
                proditem.CategoryId = product.CategoryId;
                proditem.BrandId = product.BrandId;
                proditem.Quantity = product.Quantity;
                proditem.Price = product.Price;
            }
        }
    }
}
