using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities
{
    public class Filee : BaseEntity
    {
        public string ContentType { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public Blogg? Blog { get; set; }
    }
}
