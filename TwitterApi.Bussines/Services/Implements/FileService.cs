using AutoMapper;
using TwitterApi.Bussines.Dtos.FileDtos;
using TwitterApi.Core.Entities;
using TwitterApi.DAL.Repositories.Interfaces;

namespace TwitterApi.Bussines.Services.Implements
{
    public class FileService : IFileService
    {
        IFileRepository _repo { get; }
        IMapper _mapper { get; }
        public FileService(IFileRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
            where T : class
        {
            return _mapper.Map<IEnumerable<T>>(await _repo.GetAllAsync());
        }

        public async Task<T> GetByIdAsync<T>(int? id) where T : class
        => _mapper.Map<T>(await CheckIdAsync(id, false));

        public async Task CreateAsync(FileCreateDto dto)
        {
            foreach (var item in dto.Files)
            {
                var file = await item.SaveAsync(PathConstants.PostFile);
                FileEntity entity = new FileEntity();
                entity.Path = file.Item1;
                entity.Name = file.Item2;
                entity.ContentType = item.ContentType;
                await _repo.CreateAsync(entity);
                await _repo.SaveAsync();
            }
        }

        public async Task UpdateAsync(int? id, FileUpdateDto dto)
        {
            var entity = await CheckIdAsync(id);
            foreach (var item in dto.Files)
            {
                await item.UpdateAsync(entity.Path);
                entity.UpdateTime = DateTime.UtcNow;
                await _repo.SaveAsync();
            }
        }

        public async Task RemoveAsync(int? id)
        {
            var item = await CheckIdAsync(id);
            _repo.Remove(item);
            item.Path.FileRemove();
            await _repo.SaveAsync();
        }

        public async Task SoftRemoveAsync(int? id)
        {
            var item = await CheckIdAsync(id);
            item.IsDeleted = true;
            await _repo.SaveAsync();
        }

        public async Task<FileEntity> CheckIdAsync(int? id, bool isTrack = true)
        {
            if (id < 1 || id == null)
                throw new ArgumentOutOfRangeException();
            var item = await _repo.GetByIdAsync(id);
            if (item == null)
                throw new NotFoundException<FileEntity>("File Not Found");
            return item;
        }
    }
}
