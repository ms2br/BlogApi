using System.Linq.Expressions;
using TwitterApi.Core.Entities.Common;
using TwitterApi.Core.Entities.Identity;

namespace TwitterApi.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IQueryable<T>> GetAllAsync(bool noTracking = false, params string[] includes);
        Task<T> GetByIdAsync(int? id, bool noTracking = true, params string[] includes);
        Task CreateAsync(T data);
        Task SaveAsync();
        Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);
        void Remove(T data);
    }
}
