using FluentValidation;

namespace TwitterApi.Bussines.Dtos.AppUserDtos
{
    public class LoginDto
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }

    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.UserNameOrEmail)
                .MaximumLength(255)
                .MinimumLength(4)
                .NotEmpty();

            RuleFor(x => x.Password)
            .Matches(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$")
            .NotEmpty();
        }
    }
}
