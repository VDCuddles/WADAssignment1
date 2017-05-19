using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WADAssignment1.Models
{
    public class OrderDetail
    {
		public int OrderDetailId { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		public Bag Bag { get; set; }
		public NewOrder NewOrder { get; set; }

	}
}
