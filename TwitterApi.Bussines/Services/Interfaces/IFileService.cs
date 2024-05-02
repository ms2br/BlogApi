using Microsoft.AspNetCore.Http;
using TwitterApi.Bussines.Dtos.FileDtos;
using TwitterApi.Core.Entities;

namespace TwitterApi.Bussines.Services.Interfaces
{
    public interface IFileService
    {
        Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
        Task<T> GetByIdAsync<T>(int? id) where T : class;
        Task<FileEntity> CreateAsync(IFormFile file);
        Task RemoveAsync(int? id);
        Task SoftRemoveAsync(int? id);
        protected Task<FileEntity> CheckIdAsync(int? id, bool isTrack = true);
        public Task UpdateAsync(int? id, FileUpdateDto dto);
    }
}
