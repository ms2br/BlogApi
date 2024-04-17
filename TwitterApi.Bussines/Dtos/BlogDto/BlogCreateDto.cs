using FluentValidation;

namespace TwitterApi.Bussines.Dtos.BlogDto
{
    public class BlogCreateDto
    {
        public string Content { get; set; }
        public string UserId { get; set; }
        public IEnumerable<int> FileIds { get; set; }
        public IEnumerable<int> TopicIds { get; set; }
    }

    public class BlogCreateDtoValidator : AbstractValidator<BlogCreateDto>
    {
        public BlogCreateDtoValidator()
        {
            RuleFor(x => x.Content)
                .MaximumLength(1024)
                .MinimumLength(3)
                .NotEmpty();
        }
    }
}
