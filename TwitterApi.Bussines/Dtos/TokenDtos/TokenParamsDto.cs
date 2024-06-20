using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterApi.Core.Entities.Identity;

namespace TwitterApi.Bussines.Dtos.TokenDtos
{
    public class TokenParamsDto
    {
        public AppUser AppUser { get; set; }
        public string Role { get; set; }
        public double Hours { get; set; }
    }
}
