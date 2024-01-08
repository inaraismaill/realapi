using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities
{
    public class BloggTopic : BaseEntity
    {
        public int BloggId { get; set; }
        public int TopicId { get; set; }
        public Blogg? Blogg { get; set; }
        public Topic? Topic { get; set; }
    }
}
