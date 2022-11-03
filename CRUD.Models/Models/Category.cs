using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Models.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool Status { get; set; }
    }
}
