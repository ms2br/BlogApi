using AutoMapper;
using TwitterApi.Bussines.Dtos.BlogDto;
using TwitterApi.Bussines.Dtos.TopicDtos;
using TwitterApi.Core.Entities;

namespace TwitterApi.Bussines.Profiles
{
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {        
            CreateMap<BlogCreateDto, Blog>();
            CreateMap<Blog, BlogDetailDto>();
        }
    }
}
