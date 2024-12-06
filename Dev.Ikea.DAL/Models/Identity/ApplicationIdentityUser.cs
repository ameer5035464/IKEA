using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Ikea.DAL.Models.Identity
{
	public class ApplicationIdentityUser : IdentityUser
	{
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;

        public bool IsAgree { get; set; }
    }
}
