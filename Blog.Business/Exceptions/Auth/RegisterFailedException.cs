using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Exceptions.Auth
{
    public class RegisterFailedException : Exception 
    {
        public RegisterFailedException():base("Register failed")
        {
        }

        public RegisterFailedException(string? message) : base(message)
        {
        }
    }
}
