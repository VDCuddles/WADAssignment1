﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WADAssignment1.Models.ShoppingCartViewModels
{
    public class ShoppingCartViewModel
    {
		public List<CartItem> CartItems { get; set; }
		public decimal CartTotal { get; set; }
	}
}