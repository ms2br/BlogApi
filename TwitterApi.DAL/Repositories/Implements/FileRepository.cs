using TwitterApi.Core.Entities;
using TwitterApi.DAL.Context;
using TwitterApi.DAL.Repositories.Interfaces;

namespace TwitterApi.DAL.Repositories.Implements
{
    public class FileRepository : GenericRepository<FileEntity>, IFileRepository
    {
        public FileRepository(TwitterDbContext db) : base(db)
        {

        }
    }
}
