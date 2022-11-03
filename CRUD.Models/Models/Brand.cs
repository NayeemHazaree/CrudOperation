using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Models.Models
{
    public class Brand
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool Status { get; set; }
    }
}
