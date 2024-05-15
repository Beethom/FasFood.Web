using System;
using Microsoft.AspNetCore.Identity;

namespace FastFood.Models
{
	public class ApplicationUser:IdentityUser
	{
		public string Name { get; set; }

        public string city { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }

    }
}

