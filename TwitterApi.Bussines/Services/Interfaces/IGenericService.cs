using TwitterApi.Core.Entities.Common;

namespace TwitterApi.Bussines.Services.Interfaces
{
    public interface IGenericService<TEntity, TDto>
    where TEntity : BaseEntity
    where TDto : class
    {
        Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
        Task<T> GetByIdAsync<T>(int? id) where T : class;
        Task CreateAsync(TDto dto);
        Task RemoveAsync(int? id);
        Task SoftRemoveAsync(int? id);
        protected Task<TEntity> CheckIdAsync(int? id, bool isTrack = true);
    }
}
