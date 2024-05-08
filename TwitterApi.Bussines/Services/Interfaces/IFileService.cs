using Microsoft.AspNetCore.Http;
using TwitterApi.Bussines.Dtos.BlogDtos;
using TwitterApi.Bussines.Dtos.FileDtos;
using TwitterApi.Core.Entities;

namespace TwitterApi.Bussines.Services.Interfaces
{
    public interface IFileService
    {
        Task<FileEntity> CreateAsync(IFormFile file);
        Task RemoveAsync(FileEntity file);
        Task RemoveAsync(BlogUpdateDetailDto blog, int? id);
        Task UpdateAsync(IFormFile file, BlogUpdateDetailDto blog, int? id);
    }
}
