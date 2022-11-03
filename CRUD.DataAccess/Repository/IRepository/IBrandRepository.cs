using CRUD.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DataAccess.Repository.IRepository
{
    public interface IBrandRepository : IRepository<Brand>
    {
        Task Update(Brand brand);
    }
}
