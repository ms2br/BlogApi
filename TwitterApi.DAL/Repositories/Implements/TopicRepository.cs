using TwitterApi.Core.Entities;
using TwitterApi.DAL.Context;
using TwitterApi.DAL.Repositories.Interfaces;

namespace TwitterApi.DAL.Repositories.Implements
{
    public class TopicRepository : GenericRepository<Topic>, ITopicRepository
    {
        public TopicRepository(TwitterDbContext db) : base(db)
        {
        }
    }
}
