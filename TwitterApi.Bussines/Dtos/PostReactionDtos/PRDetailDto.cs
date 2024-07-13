using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterApi.Bussines.Dtos.BlogDtos;
using TwitterApi.Bussines.Dtos.UserDtos;
using TwitterApi.Core.Entities;
using TwitterApi.Core.Entities.Identity;
using TwitterApi.Core.Enums;

namespace TwitterApi.Bussines.Dtos.PostReactionDtos
{
    public class PRDetailDto
    {
        public UserDto? AppUser { get; set; }
        public PostDetailDto? Post { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string AppUserId { get; set; }
        public Reactions Reaction { get; set; }
    }
}
