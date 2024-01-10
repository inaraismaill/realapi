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
<<<<<<< HEAD
        public string Fullname { get; set; }
=======
        public string Name { get; set; }
        public string Surname { get; set; }
>>>>>>> 5d78b326896165b775f4d0574c9e183cd6ec5cc1
        public DateTime Birthday { get; set; }
    }
}
