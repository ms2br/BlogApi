using TwitterApi.Bussines.Dtos.BlogDtos;
using TwitterApi.Bussines.Dtos.FileDtos;
using TwitterApi.Bussines.Dtos.TopicDtos;
using TwitterApi.Core.Entities;

namespace TwitterApi.Bussines.Services.Interfaces
{
    public interface IPostService : IGenericService<Post, PostCreateDto>
    {
        Task UpdateAsync(int? id, PostUpdateDto updateDto, params string[] includes);

        Task RemoveImgFilesAsync(int? blogId, int? fileId, params string[] includes);

        Task UpdateImgFilesAsync(int? blogId, int? fileId, FileUpdateDto file, params string[] includes);
    }
}
