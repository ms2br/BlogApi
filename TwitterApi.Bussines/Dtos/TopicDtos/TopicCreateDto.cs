using FluentValidation;

namespace TwitterApi.Bussines.Dtos.TopicDtos
{
    public class TopicCreateDto
    {
        public string Name { get; set; }
    }

    public class TopicCreateDtoValidator : AbstractValidator<TopicCreateDto>
    {
        public TopicCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(32)
                .MinimumLength(3)
                .NotEmpty();
        }
    }
}
