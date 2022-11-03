using CRUD.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DataAccess.Repository.IRepository
{
    public interface IProductRepository :IRepository<Product>
    {
         Task Update(Product product);
         Task<IEnumerable<SelectListItem>> DropDownList(string obj);
    }
}
