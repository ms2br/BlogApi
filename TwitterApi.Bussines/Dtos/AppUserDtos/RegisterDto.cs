using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace TwitterApi.Bussines.Dtos.AppUserDtos
{
    public class RegisterDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime BirthDate { get; set; }
        public IFormFile? ImgUrl { get; set; }
    }

    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.UserName)
                .MaximumLength(32)
                .NotEmpty();

            RuleFor(x => x.Email)
                .MaximumLength(255)
                .MinimumLength(4)
                .NotEmpty();

            RuleFor(x => x.BirthDate)
                .LessThan(DateTime.Now.AddYears(-18))
                .NotEmpty();

            RuleFor(x => x.Password)
                .Matches(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$")
                .NotEmpty();

            RuleFor(t => t)
                .Must(t => t.Password == t.ConfirmPassword)
                .NotEmpty();
        }
    }
}
