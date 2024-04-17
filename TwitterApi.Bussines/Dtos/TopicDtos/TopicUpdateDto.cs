using FluentValidation;

namespace TwitterApi.Bussines.Dtos.TopicDtos
{
    public class TopicUpdateDto
    {
        public string Name { get; set; }
    }

    public class TopicUpdateValidator : AbstractValidator<TopicUpdateDto>
    {
        public TopicUpdateValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(32)
                .MinimumLength(3)
                .NotEmpty();
        }
    }
}
