using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterApi.Bussines.Dtos.BlogDtos
{
    public class BlogUpdateDto
    {
        public string Content { get; set; }
        public IEnumerable<IFormFile>? FormFiles { get; set; }
        public IEnumerable<int>? TopicIds { get; set; }
    }

    public class BlogUpdateDtoValidator:AbstractValidator<BlogUpdateDto>
    {
        public BlogUpdateDtoValidator()
        {
            RuleFor(x=> x.Content)
                .MaximumLength(1024)
                .MinimumLength(3)
                .NotEmpty();

            RuleFor(x => x.TopicIds)
                .NotEmpty()
                    .WithMessage("The Topic Must Not Be Empty");
        }
    }
}
