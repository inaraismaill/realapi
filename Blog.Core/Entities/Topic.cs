using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities
{
    public class Topic : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<BloggTopic>? BloggTopics { get; set; }
    }
}
