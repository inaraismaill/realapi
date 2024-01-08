using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Dtos.BloggDtos
{
    public class BlogCreateDto
    {
        public string Description { get; set; }
        public int? UserId { get; set; }
    }
    public class BlogCreateDTOValidation : AbstractValidator<BlogCreateDto>
    {
        public BlogCreateDTOValidation()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(1024);
        }
    }
}
