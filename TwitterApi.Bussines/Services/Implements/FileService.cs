using AutoMapper;
using Microsoft.AspNetCore.Http;
using TwitterApi.Bussines.Dtos.BlogDtos;
using TwitterApi.Bussines.Dtos.FileDtos;
using TwitterApi.Bussines.Helpers;
using TwitterApi.Core.Entities;
using TwitterApi.DAL.Repositories.Interfaces;

namespace TwitterApi.Bussines.Services.Implements
{
    public class FileService: IFileService
    {
        IFileRepository _repo { get; }
        IMapper _mapper { get; }
        public FileService(IFileRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<FileEntity> CreateAsync(IFormFile file)
        {
            var fileInfo = await file.SaveAsync(PathConstants.PostFile);
            FileEntity entity = new FileEntity();
            entity.Path = fileInfo.Item1;
            entity.Name = fileInfo.Item2;
            entity.ContentType = file.ContentType;
            return entity;
        }

        public async Task UpdateAsync(IFormFile file, BlogUpdateDetailDto blog,int? id)
        {
            var item = GetByFile(id, blog);
            await file.UpdateAsync(item.Path);
            item.UpdateTime = DateTime.UtcNow;
            await _repo.SaveAsync();
        }

        public async Task RemoveAsync(FileEntity file)
        {
            _repo.Remove(file);
            file.Path.FileRemove();
            await _repo.SaveAsync();
        }

        public async Task RemoveAsync(BlogUpdateDetailDto blog, int? id)
        {
            var file = GetByFile(id, blog);
            _repo.Remove(file);
            file.Path.FileRemove();
            await _repo.SaveAsync();
        }

        FileEntity GetByFile(int? id, BlogUpdateDetailDto blog)
        => blog.Files.FirstOrDefault(x => x.Id == id) ?? throw new NotFoundException<FileEntity>();
    }
}
