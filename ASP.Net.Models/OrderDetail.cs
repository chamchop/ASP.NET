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
	public class OrderDetail
	{
		public int Id { get; set; }

		[ForeignKey("OrderId")]
		[Required]
		public int OrderId { get; set; }

		[ValidateNever]
		public OrderHeader OrderHeader { get; set; }

		[ForeignKey("ProductId")]
		[Required]
		public int ProductId { get; set; }

		[ValidateNever]
		public Product Product { get; set; }

		public int Count { get; set; }

		public double Price { get; set; }
	}
}
