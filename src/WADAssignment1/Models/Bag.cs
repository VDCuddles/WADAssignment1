﻿using System;
using System.Collections.Generic;
namespace WADAssignment1.Models
{
	public class Bag
	{
		public int ID { get; set; }
		public int SupplierID { get; set; }
		public string Name { get; set; }
		public string CategoryName { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public double Price { get; set; }
	}
}