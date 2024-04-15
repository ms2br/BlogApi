using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace TwitterApi.Bussines.Dtos.FileDtos
{
    public class FileCreateDto
    {
        public IEnumerable<IFormFile> Files { get; set; }
    }

    public class FileCreateDtoValidator : AbstractValidator<FileCreateDto>
    {
        public FileCreateDtoValidator()
        {
            RuleFor(x => x.Files)
                .Must(f => f.Any(i => i.IsCorrectType()))
                    .WithMessage(ExceptionMessages.InCorrectTypeMessage)
                 .Must(f => f.Any(i => i.IsValidSize()))
                    .WithMessage(ExceptionMessages.InValidSizeMessage)
                 .NotEmpty();
        }
    }
}
