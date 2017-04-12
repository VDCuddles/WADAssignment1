using System;
using System.Collections.Generic;
namespace WADAssignment1.Models
{
	public class Order
	{
		public int ID { get; set; }
		public ICollection<Bag> Bags { get; set; }
		public int CustomerID { get; set; }
		public double Subtotal { get; set; }
		public double GST { get; set; }
		public double GrandTotal { get; set; }

	}
}