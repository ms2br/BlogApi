using System.Linq.Expressions;
using TwitterApi.Core.Entities.Common;

namespace TwitterApi.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IQueryable<T>> GetAllAsync(bool noTracking = false);
        Task<T> GetByIdAsync(int? id, bool noTracking = true);
        Task CreateAsync(T data);
        Task SaveAsync();
        Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);
        void Remove(T data);
    }
}
