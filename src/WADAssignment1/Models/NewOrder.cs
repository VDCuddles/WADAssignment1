using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WADAssignment1.Models
{
    public class NewOrder
    {
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string PostalCode { get; set; }
		public string Country { get; set; }
		public string Phone { get; set; }
		public decimal Total { get; set; }
		public System.DateTime OrderDate { get; set; }
		public List<OrderDetail> OrderDetails { get; set; }
		public ApplicationUser User { get; set; }

	}
}
