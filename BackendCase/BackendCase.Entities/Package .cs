using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendCase.Entities
{
	public class Package
	{
		public int ID { get; set; }
		[Required]
		public int Weight { get; set; }
		[Required]
		public decimal Price { get; set; }

		public float ValuePerKilo { get; set; }
		public int ShipmentStatus { get; set; }
		public int ShipmentId { get; set; }
	}
}
