using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net.Models
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
        public string Author{ get; set; }

        [Required]
        [Range(1, 10000)]
        [Display(Name = "RRP")]
        public double ListPrice { get; set; }

        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }

        [Required]
        [Range(1, 10000)]
        public double BulkPrice { get; set; }

        [ValidateNever]
        public string ImageURL { get; set; }

        [Required]
        [ValidateNever]
        public Category Category { get; set; }

        [ForeignKey("CategoryId")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }      
        
        [ValidateNever]
        public CoverType CoverType { get; set; }
        
        [Required]
        [Display(Name = "Cover Type")]
        public int CoverTypeId { get; set; }            
    }
}
