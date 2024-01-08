using Blog.Business.Repositories.Interfaces;
using Blog.Core.Entities;
using Blog.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Repositories.Implements
{
    public class BloggRepositories : GenericRepository<Blogg>, IBloggRepositories
    {
        public BloggRepositories(BlogContext context) : base(context)
        {
        }
    }
}
