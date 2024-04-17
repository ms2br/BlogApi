using Microsoft.AspNetCore.Identity;

namespace TwitterApi.Core.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string? ImgUrl { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Blog>? Blogs { get; set; }
    }
}
