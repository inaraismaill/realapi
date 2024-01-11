using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities
{
    public class Blogg : BaseEntity
    {
        public string UserName { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public override DateTime CreatedTime { get => base.CreatedTime; set => base.CreatedTime = value; }

        public int? UserId { get; set; }
        public AppUser? AppUser { get; set; }
        public IEnumerable<Filee>? Files { get; set; }
        public IEnumerable<BloggTopic>? BloggTopics { get; set; }
    }
}

