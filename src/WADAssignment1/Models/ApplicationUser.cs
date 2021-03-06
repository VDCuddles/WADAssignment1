﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WADAssignment1.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
		public bool Enabled { get; set; }
		public String Address { get; set; }
		public String FirstName { get; set; }
		public String LastName { get; set; }
		public String HomePhone { get; set; }
		public String WorkPhone { get; set; }
		public String MobilePhone { get; set; }
	}
}
