using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterApi.Core.Entities.Identity;
using TwitterApi.Core.Entities;

namespace TwitterApi.Bussines.Dtos.BlogDtos
{
    public class PostUpdateDetailDto
    {

        public int Id { get; set; }
        public string Content { get; set; }
        public ICollection<FileEntity>? Files { get; set; }
        public ICollection<PostTopic>? Topics { get; set; }
        
        public PostUpdateDetailDto()
        {
            Files = new HashSet<FileEntity>();
            Topics = new HashSet<PostTopic>();
        }
    }
}
