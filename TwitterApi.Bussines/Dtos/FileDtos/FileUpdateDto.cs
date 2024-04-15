using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace TwitterApi.Bussines.Dtos.FileDtos
{
    public class FileUpdateDto
    {
        public List<IFormFile> Files { get; set; }
    }

    public class FileUpdateDtoValidator : AbstractValidator<FileUpdateDto>
    {
        public FileUpdateDtoValidator()
        {
            RuleFor(x => x.Files)
                .NotEmpty()
                .Must(f => f.Any(i => i.IsCorrectType()))
                    .WithMessage(ExceptionMessages.InCorrectTypeMessage)
                 .Must(f => f.All(i => i.IsValidSize()))
                    .WithMessage(ExceptionMessages.InValidSizeMessage);
        }
    }
}
