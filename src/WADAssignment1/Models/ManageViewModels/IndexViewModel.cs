﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WADAssignment1.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }

        public IList<UserLoginInfo> Logins { get; set; }

        public string Address { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string HomePhone { get; set; }

		public string WorkPhone { get; set; }

		public string MobilePhone { get; set; }

		public bool TwoFactor { get; set; }

        public bool BrowserRemembered { get; set; }
    }
}
