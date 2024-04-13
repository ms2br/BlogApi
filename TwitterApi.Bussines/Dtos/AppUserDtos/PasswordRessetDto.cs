using FluentValidation;

namespace TwitterApi.Bussines.Dtos.AppUserDtos
{
    public class PasswordRessetDto
    {
        public string Email { get; set; }
    }

    public class ChangePassworValidatorDto : AbstractValidator<PasswordRessetDto>
    {
        public ChangePassworValidatorDto()
        {
            RuleFor(x => x.Email)
                .MaximumLength(255)
                .MinimumLength(4)
                .NotEmpty();
        }
    }
}
