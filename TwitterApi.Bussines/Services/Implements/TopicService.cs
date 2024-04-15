using AutoMapper;
using TwitterApi.Bussines.Dtos.TopicDtos;
using TwitterApi.Bussines.Dtos.TopicDtos.Common;
using TwitterApi.Bussines.Exceptions.TopicException;
using TwitterApi.Core.Entities;
using TwitterApi.DAL.Repositories.Interfaces;

namespace TwitterApi.Bussines.Services.Implements
{
    public class TopicService : ITopicService
    {

        IMapper _mapper { get; }
        ITopicRepository _repo { get; }

        public TopicService(IMapper mapper, ITopicRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
            where T : class
        => _mapper.Map<IEnumerable<T>>(await _repo.GetAllAsync());

        public async Task<T> GetByIdAsync<T>(int? id)
            where T : class
        => _mapper.Map<T>(await CheckIdAsync(id, true));

        public async Task CreateAsync(TopicBaseDto dto)
        {
            await IsNameExistAsync(dto.Name);
            await _repo.CreateAsync(_mapper.Map<Topic>(dto));
            await _repo.SaveAsync();
        }

        public async Task UpdateAsync(int? id, TopicUpdateDto dto)
        {
            Topic topic = await CheckIdAsync(id);
            if (topic.Name.ToLower() == dto.Name.ToLower())
                throw new TopicIsExistException();
            await IsNameExistAsync(dto.Name);
            _mapper.Map(dto, topic);
            await _repo.SaveAsync();
        }

        public async Task RemoveAsync(int? id)
        {
            _repo.Remove(await CheckIdAsync(id));
            await _repo.SaveAsync();
        }

        public async Task SoftRemoveAsync(int? id)
        {
            var item = await CheckIdAsync(id);
            item.IsDeleted = true;
            await _repo.SaveAsync();
        }

        public async Task<Topic> CheckIdAsync(int? id, bool isTrack = false)
        {
            if (id <= 1 || id == null)
                throw new ArgumentOutOfRangeException();
            Topic? item = await _repo.GetByIdAsync(id, isTrack);
            if (item == null)
                throw new NotFoundException<Topic>();
            return item;
        }

        async Task IsNameExistAsync(string name)
        {
            if (await _repo.IsExistAsync(x => x.Name.ToLower() == name.ToLower()))
                throw new TopicIsExistException();
        }
    }
}
