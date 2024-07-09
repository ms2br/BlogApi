using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterApi.Bussines.Dtos.PostReactionDtos
{
    public class PRCreateDto
    {
        public int Reaction { get; set; }
        public int PostId { get; set; }
    }
}
