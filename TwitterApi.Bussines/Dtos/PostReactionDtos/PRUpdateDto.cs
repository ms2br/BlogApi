using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterApi.Core.Enums;

namespace TwitterApi.Bussines.Dtos.PostReactionDtos
{
    public class PRUpdateDto
    {
        public int Reaction { get; set; }
    }

    public class PRUpdateDtoValidator : AbstractValidator<PRUpdateDto>
    {
        public PRUpdateDtoValidator()
        {
            RuleFor(x => x.Reaction)
                .Must(x => Enum.IsDefined(typeof(Reactions), x))
                  .WithMessage("Reactions Not Found !")
                 .NotEmpty();               
        }
    }
}
