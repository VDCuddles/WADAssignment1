using System;
using System.Collections.Generic;
namespace WADAssignment1.Models
{
	public class Customer
	{
		public int ID { get; set; }
		public int ContactPhHome { get; set; }
		public int ContactPhWork { get; set; }
		public int ContactPhMob { get; set; }
		public string ContactEmail { get; set; }
		public string ContactAddress { get; set; }
		public string Name { get; set; }

	}
}