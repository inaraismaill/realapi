using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Dtos.AuthDtos;

public class LoginDto
{
    public string UsernameOrEmail { get; set; }
    public string Password { get; set; }
}
public class LoginDtoValidator : AbstractValidator<LoginDto>
{ 
    public LoginDtoValidator() 
    {
        RuleFor(x => x.UsernameOrEmail)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3)
            .MaximumLength(64);
        RuleFor(x => x.Password)
           .NotEmpty()
           .NotNull()
           .MinimumLength(4)
           .MaximumLength(64);
    }  
}

