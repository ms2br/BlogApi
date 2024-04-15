using FluentValidation;

namespace TwitterApi.Bussines.Dtos.FileDtos.Common
{
    public class FileBaseDto
    {
        public string Name { get; set; }
    }

    public class FileBaseDtoValidator : AbstractValidator<FileBaseDto>
    {
        public FileBaseDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(32)
                .MinimumLength(3)
                .NotEmpty();
        }
    }
}
