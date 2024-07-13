using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterApi.Core.Enums;

namespace TwitterApi.Bussines.Dtos.PostReactionDtos
{
    public class PRCreateDto
    {
        public int Reaction { get; set; }
        public int PostId { get; set; }
    }

    public class PRCreateDtoValidator:AbstractValidator<PRCreateDto>
    {
        public PRCreateDtoValidator()
        {
            RuleFor(x => x.Reaction)
                .NotEmpty()
                .Must(x => Enum.IsDefined(typeof(Reactions), x))
                .WithMessage("Reactions Not Found !");
        }
    }
}
