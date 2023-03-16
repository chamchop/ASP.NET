﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net.Models
{
	public class OrderHeader
	{
		public int Id { get; set; }

		public string Name { get; set; }

		[ForeignKey("ApplicationUserId")]
		public string ApplicationUserId { get; set; }
		[ValidateNever]
		public ApplicationUser ApplicationUser { get; set; }
		
		public DateTime OrderDate { get; set; }
		
		public DateTime ShippingDate { get; set; }
		
		public double OrderTotal { get; set; }
		
		public string? OrderStatus { get; set; }
		public string? PaymentStatus { get; set; }
		public string? Carrier { get; set; }
		public string? TrackingNumber { get; set; }
		public DateTime PaymentDate { get; set; }
		public DateTime PaymentDueDate { get; set; }
		public string? SessionId { get; set; }
		public string? PaymentIntentId { get; set; }

		[Required]
		public string PhoneNumber { get; set; }
		
		[Required]
		public string StreetAddress { get; set; }
		
		[Required]
		public string City { get; set; }
		
		[Required]
		public string State { get; set; }
		
		[Required]
		public string PostalCode { get; set; }
		
		[Required]
		public string Address { get; set; }
	}
}
