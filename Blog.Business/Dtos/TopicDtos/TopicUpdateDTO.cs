using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Dtos.TopicDtos
{
    public class TopicUpdateDTO
    {
        public string Name { get; set; }
    }
    public class TopicUpdateDTOValidator : AbstractValidator<TopicUpdateDTO>
    {
        public TopicUpdateDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(32);
        }
    }
}
