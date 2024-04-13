using FluentValidation;

namespace TwitterApi.Bussines.Dtos.TopicDtos.Common
{
    public class TopicBaseDto
    {
        public string Name { get; set; }
    }

    public class TopicBaseDtoValidator : AbstractValidator<TopicCreateDto>
    {
        public TopicBaseDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(32)
                .MinimumLength(3)
                .NotEmpty();
        }
    }
}
