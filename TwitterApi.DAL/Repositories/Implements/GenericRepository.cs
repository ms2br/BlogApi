using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TwitterApi.Core.Entities.Common;
using TwitterApi.DAL.Context;
using TwitterApi.DAL.Repositories.Interfaces;

namespace TwitterApi.DAL.Repositories.Implements
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        TwitterDbContext _db { get; }
        public GenericRepository(TwitterDbContext db)
        {
            _db = db;
        }

        DbSet<T> Table => _db.Set<T>();

        public async Task<IQueryable<T>> GetAllAsync(bool noTracking = true)
        => noTracking ? Table.AsNoTracking() : Table;

        public async Task CreateAsync(T data)
        => await Table.AddAsync(data);

        public async Task SaveAsync()
        => await _db.SaveChangesAsync();

        public async Task<T> GetByIdAsync(int? id, bool noTracking = true)
        => noTracking ? await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id) : await Table.FindAsync(id);

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
        => await Table.AnyAsync(expression);

        public void Remove(T data)
        => Table.Remove(data);
    }
}
