using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Dtos.BloggDtos
{
    public class BloggUpdateDto
    {
        public string Description { get; set; }
        public int? UserId { get; set; }
    }
    public class BloggUpdateDTOValidation : AbstractValidator<BloggUpdateDto>
    {
        public BloggUpdateDTOValidation()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(1024);
        }
    }
}
