using AutoMapper;
using AutoMapper.Execution;
using TwitterApi.Bussines.Dtos.BlogDtos;
using TwitterApi.Bussines.Dtos.TopicDtos;
using TwitterApi.Bussines.Dtos.UserDtos;
using TwitterApi.Core.Entities;
using TwitterApi.Core.Entities.Identity;

namespace TwitterApi.Bussines.Profiles
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {        
            CreateMap<PostCreateDto, Post>();
            CreateMap<PostUpdateDetailDto, Post>().ReverseMap();
            CreateMap<Post, PostDetailDto>()
            .BeforeMap((src, dest, context) =>
            {
                dest.TopicDetails = context.Mapper.Map<IEnumerable<TopicDetailDto>>(src.Topics.Select(x => x.Topic));
                dest.AppUser = context.Mapper.Map<UserPostDto>(src.AppUser);
            });
        }
    }
}
