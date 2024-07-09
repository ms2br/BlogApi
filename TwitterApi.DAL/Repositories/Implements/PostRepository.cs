using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TwitterApi.Core.Entities;
using TwitterApi.DAL.Context;
using TwitterApi.DAL.Repositories.Interfaces;

namespace TwitterApi.DAL.Repositories.Implements
{
    public class PostRepository : GenericRepository<Post>,
        IPostRepository
    {
        public PostRepository(TwitterDbContext db) : base(db)
        {
        }
    }
}
