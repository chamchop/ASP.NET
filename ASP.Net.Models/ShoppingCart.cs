﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        [ForeignKey("ProductId")]
        [ValidateNever]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Range(1, 1000, ErrorMessage = "Please enter valid value.")]
        public int Count { get; set; }

        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public double Price { get; set; }
    }
}
