using TwitterApi.Core.Entities.Common;

namespace TwitterApi.Bussines.Services.Interfaces
{
    public interface IGenericService<TEntity, TDto>
    where TEntity : BaseEntity
    where TDto : class
    {
        Task<IEnumerable<T>> GetAllAsync<T>(params string[] includes) where T : class;
        Task<T> GetByIdAsync<T>(int? id, params string[] includes) where T : class;
        Task CreateAsync(TDto dto);
        Task RemoveAsync(int? id,params string[] includes);
        Task SoftRemoveAsync(int? id, params string[] includes);
        Task<bool> IsExistAsync(int? id);
        protected Task<TEntity> CheckIdAsync(int? id, bool isTrack = true, params string[] includes);
    }
}
