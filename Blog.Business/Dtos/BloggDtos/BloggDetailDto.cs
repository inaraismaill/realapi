using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Dtos.BloggDtos
{
    public class BloggDetailDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string Description { get; set; }
        public int? UserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
