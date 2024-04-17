using FluentValidation;

namespace TwitterApi.Bussines.Dtos.FileDtos
{
    public class FileDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class FileDetailDtoValidator : AbstractValidator<FileDetailDto>
    {
        public FileDetailDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(32)
                .MinimumLength(3)
                .NotEmpty();
        }
    }
}
