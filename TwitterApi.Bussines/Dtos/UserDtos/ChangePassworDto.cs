using FluentValidation;

namespace TwitterApi.Bussines.Dtos.UserDtos
{
    public class ChangePassworDto
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class PasswordResetDtoValidator : AbstractValidator<ChangePassworDto>
    {
        public PasswordResetDtoValidator()
        {
            RuleFor(x => x.CurrentPassword)
                .Matches(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$")
                .NotEmpty();

            RuleFor(x => x.NewPassword)
                .Matches(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$")
                .NotEmpty();

            RuleFor(x => x)
                .Must(x => x.ConfirmPassword == x.NewPassword);
        }
    }
}
