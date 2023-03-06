using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net.Models
{
    public class ShoppingCart
    {
        public Product Product { get; set; }

        [Range(1, 1000, ErrorMessage = "Please enter valid value.")]
        public int Count { get; set; }
    }
}
