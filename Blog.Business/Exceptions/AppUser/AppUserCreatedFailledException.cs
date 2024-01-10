using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Exceptions.AppUser
{
    public class AppUserCreatedFailledException : Exception
    {
        public AppUserCreatedFailledException() : base("User cannot be created") { }

        public AppUserCreatedFailledException(string? message) : base(message)
        {
        }
    }
}
