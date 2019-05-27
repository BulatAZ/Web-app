using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestAccounting3.Models
{
    public class User : IdentityUser 
    {
        //public string FullName { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }
    }
}
