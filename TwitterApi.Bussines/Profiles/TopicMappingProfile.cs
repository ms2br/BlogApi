using AutoMapper;
using TwitterApi.Bussines.Dtos.TopicDtos;
using TwitterApi.Core.Entities;

namespace TwitterApi.Bussines.Profiles
{
    public class TopicMappingProfile : Profile
    {
        public TopicMappingProfile()
        {
            CreateMap<TopicCreateDto, Topic>();
            CreateMap<Topic, TopicDetailDto>();
            CreateMap<TopicUpdateDto, Topic>();
        }
    }
}
