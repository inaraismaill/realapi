using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Dtos.AuthDtos
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDay { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).MaximumLength(16);
            RuleFor(x => x.Surname).NotEmpty().MinimumLength(2).MaximumLength(32);
            RuleFor(x => x.Username).NotEmpty().MinimumLength(6).MaximumLength(16);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().Must(_ValidEmail).WithMessage("Invalid email.");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(4).MaximumLength(32);
            RuleFor(x => x.BirthDay).NotEmpty().Must(_MaxBirthDay).Must(_MinBirthDay).WithMessage("Invalid birthday.");
        }

        private bool _ValidEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }
        private bool _MaxBirthDay(DateTime birthDay)
        {
            return birthDay >= DateTime.Now.AddYears(-100);
        }
        private bool _MinBirthDay(DateTime birthDay)
        {
            return birthDay >= DateTime.Now.AddYears(-18);
        }
    }
}
