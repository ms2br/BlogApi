using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterApi.Bussines.Dtos.TopicDtos;
using TwitterApi.Core.Entities;

namespace TwitterApi.Bussines.Helpers
{
    public static class StaticAutoMapper
    {
        public static IMapper mapper { get; set; }

        public static IEnumerable<TopicDetailDto> TopicDetailsMapper(this IEnumerable<Topic> source)
        => mapper.Map<IEnumerable<TopicDetailDto>>(source);
    }
}
