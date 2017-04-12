using System;
using System.Collections.Generic;
namespace ContosoUniversity.Models
{
	public class Order
	{
		public ICollection<Bag> Bags { get; set; }
		public int CustomerID { get; set; }
		public float Subtotal { get; set; }
		public float GST { get; set; }
		public float GrandTotal { get; set; }

	}
}