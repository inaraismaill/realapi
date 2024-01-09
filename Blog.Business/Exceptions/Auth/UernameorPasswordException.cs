using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Exceptions.Auth
{
    public class UernameorPasswordException : Exception
    {
        public UernameorPasswordException(): base("Uername or password is wrong")
        {
        }

        public UernameorPasswordException(string? message) : base(message)
        {
        }
    }
}
