using AutoMapper;
using TwitterApi.Core.Entities.Identity;

namespace TwitterApi.Bussines.Profiles
{
    public class AppUserMappingProfile : Profile
    {
        public AppUserMappingProfile()
        {
            CreateMap<RegisterDto, AppUser>();
            CreateMap<AppUser, UserDto>()
                .ForMember(x => x.UserId, u => u.MapFrom(i => i.Id))
                .ReverseMap();
        }
    }
}
