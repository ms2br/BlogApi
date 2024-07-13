using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterApi.Bussines.Dtos.PostReactionDtos;
using TwitterApi.Core.Entities;
using TwitterApi.Core.Enums;

namespace TwitterApi.Bussines.Profiles
{
    public class PostReactionMappingProfile : Profile
    {
        public PostReactionMappingProfile()
        {
            CreateMap<PostReaction,PRDetailDto>();
            CreateMap<PRCreateDto, PostReaction>()                
                .ForMember(r => r.Reaction, opt => opt.MapFrom(x => x.Reaction));

            CreateMap<PRUpdateDto, PostReaction>()
                .ForMember(r => r.Reaction, opt => opt.MapFrom(x=> x.Reaction));

        }
    }
}
