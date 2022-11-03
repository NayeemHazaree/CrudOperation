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
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Range(1,1000,ErrorMessage ="Can't be 0 or greater than 1000")]
        public int Price { get; set; }
        public int Quantity { get; set; }
        [Required]
        [DisplayName("Category")]
        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
        [Required]
        [DisplayName("Brand")]
        public Guid BrandId { get; set; }
        [ForeignKey("BrandId")]
        public virtual Brand? Brand { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem>? CategoryList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem>? BrandList { get; set; }
    }
}
