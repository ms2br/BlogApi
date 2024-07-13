using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TwitterApi.Core.Entities.Common;
using TwitterApi.Core.Entities.Identity;
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

       protected DbSet<T> Table => _db.Set<T>();

        public async Task<IQueryable<T>> GetAllAsync(bool noTracking = true, params string[] includes)
        {
            var items = await includeMultiplesAsync(Table.AsQueryable(), includes);
            return noTracking ? items.AsNoTracking() : items;
        }

        public async Task CreateAsync(T data)
        => await Table.AddAsync(data);

        public async Task SaveAsync()
        => await _db.SaveChangesAsync();

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> expression, bool noTracking = true, params string[] includes)
        {
            var item = await includeMultiplesAsync(Table.AsQueryable(), includes);
            return noTracking ? await item.AsNoTracking().FirstOrDefaultAsync(expression) : await item.FirstOrDefaultAsync(expression);
        }

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
        => await Table.AnyAsync(expression);

        public void Remove(T data)
        => Table.Remove(data);        

        protected async Task<IQueryable<T>> includeMultiplesAsync(IQueryable<T> includeQuery, params string[] includes)
        {
            if(includes.Length > 0 && includes != null)
                foreach (var include in includes)
                    includeQuery = includeQuery.Include(include);
            return includeQuery;
        }
    }
}
