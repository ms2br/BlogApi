using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace TwitterApi.Bussines.Dtos.BlogDto
{
    public class BlogCreateDto
    {
        public string Content { get; set; }
        public IEnumerable<IFormFile>? FormFiles { get; set; }
        public IEnumerable<int>? TopicIds { get; set; }
    }

    public class BlogCreateDtoValidator : AbstractValidator<BlogCreateDto>
    {
        public BlogCreateDtoValidator()
        {
            RuleFor(x => x.Content)
                .MaximumLength(1024)
                .MinimumLength(3)
                .NotEmpty();

            RuleFor(x => x.TopicIds)
                .NotEmpty()
                    .WithMessage("The Topic Must Not Be Empty");
        }
    }
}
