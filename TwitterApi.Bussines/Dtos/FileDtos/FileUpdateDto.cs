using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace TwitterApi.Bussines.Dtos.FileDtos
{
    public class FileUpdateDto
    {
        public IFormFile File { get; set; }
    }

    public class FileUpdateDtoValidator : AbstractValidator<FileUpdateDto>
    {
        public FileUpdateDtoValidator()
        {
            RuleFor(x => x.File)
                .NotEmpty()
                 .Must(f => f.IsValidSize())
                    .WithMessage(ExceptionMessages.InValidSizeMessage);
        }
    }
}
