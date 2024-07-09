using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterApi.Core.Entities;
using TwitterApi.DAL.Context;
using TwitterApi.DAL.Repositories.Interfaces;

namespace TwitterApi.DAL.Repositories.Implements
{
    public class PostReactionRepository
        : GenericRepository<PostReaction>, IPostReactionRepository
    {
        public PostReactionRepository(TwitterDbContext db) : base(db)
        {

        }
    }
}
