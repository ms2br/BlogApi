using FluentValidation;

namespace TwitterApi.Bussines.Dtos.AppUserDtos
{
    public class UpdatePasswordDto
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class UpdatePasswordDtoValidator : AbstractValidator<UpdatePasswordDto>
    {
        public UpdatePasswordDtoValidator()
        {
            RuleFor(x => x.UserId)
                 .NotEmpty();

            RuleFor(x => x.Token)
                .NotEmpty();

            RuleFor(x => x.Password)
                .Matches(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$")
                .NotEmpty();

            RuleFor(x => x)
                .Must(x => x.ConfirmPassword == x.Password)
                .NotEmpty();
        }
    }
}
