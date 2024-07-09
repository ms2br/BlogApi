using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterApi.Core.Entities.Common;
using TwitterApi.Core.Entities.Identity;
using TwitterApi.Core.Enums;

namespace TwitterApi.Core.Entities
{
    public class PostReaction:BaseEntity
    {
        public int PostId { get; set; }
        public string AppUserId { get; set; }
        public Post? Post { get; set; }
        public AppUser? AppUser { get; set; }
        public Reactions Reaction { get; set; }
    }
}
