using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Author { get; set; }

        [Range(1, 10000)]
        [Required]
        public double ListPrice { get; set; }

        [Range(1, 10000)]
        [Required]
        public double Price { get; set; }

        [Range(1, 10000)]
        [Required]
        public double Price50 { get; set; }

        [Range(1, 10000)]
        [Required]
        public double Price100 { get; set; }

        public string ImageUrl { get; set; }

        // foreign keys below, automatically detected by EF-Core
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        public int CoverTypeId { get; set; }
        public CoverType CoverType { get; set; }
    }
}
