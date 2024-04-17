using AutoMapper;
using TwitterApi.Bussines.Dtos.BlogDto;
using TwitterApi.Core.Entities;

namespace TwitterApi.Bussines.Profiles
{
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<BlogCreateDto, Blog>();
        }
    }
}
