using AutoMapper;
using AutoMapper.Execution;
using TwitterApi.Bussines.Dtos.BlogDtos;
using TwitterApi.Bussines.Dtos.TopicDtos;
using TwitterApi.Bussines.Dtos.UserDtos;
using TwitterApi.Core.Entities;
using TwitterApi.Core.Entities.Identity;

namespace TwitterApi.Bussines.Profiles
{
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {        
            CreateMap<BlogCreateDto, Post>();
            CreateMap<BlogUpdateDetailDto, Post>().ReverseMap();
            CreateMap<Post, BlogDetailDto>()
            .BeforeMap((src, dest, context) =>
            {
                dest.TopicDetails = context.Mapper.Map<IEnumerable<TopicDetailDto>>(src.Topics.Select(x => x.Topic));
                dest.AppUser = context.Mapper.Map<UserPostDto>(src.AppUser);
            });
        }
    }
}
