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
    public class TopicRepositories : GenericRepository<Topic>, ITopicRepositories
    {
        public TopicRepositories(BlogContext context) : base(context)
        {
        }
    }
}
