using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string Fullname { get; set; }
        public DateTime Birthday { get; set; }
    }
}
