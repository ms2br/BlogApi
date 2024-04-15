using TwitterApi.Bussines.Dtos.FileDtos;
using TwitterApi.Core.Entities;

namespace TwitterApi.Bussines.Services.Interfaces
{
    public interface IFileService : IGenericService<FileEntity, FileCreateDto>
    {
        public Task UpdateAsync(int? id, FileUpdateDto dto);
    }
}
