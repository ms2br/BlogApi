using AutoMapper;
using TwitterApi.Bussines.Dtos.TopicDtos;
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

        public async Task<IEnumerable<T>> GetAllAsync<T>(params string[] includes)
            where T : class
        => _mapper.Map<IEnumerable<T>>(await _repo.GetAllAsync(false,includes));

        public async Task<T> GetByIdAsync<T>(int? id, params string[] includes)
            where T : class
        => _mapper.Map<T>(await CheckIdAsync(id, true,includes));

        public async Task CreateAsync(TopicCreateDto dto)
        {
            #region IsNameExistAsync
            //await IsNameExistAsync(dto.Name);
            #endregion
         
            await _repo.CreateAsync(_mapper.Map<Topic>(dto));
            await _repo.SaveAsync();
        }

        public async Task UpdateAsync(int? id, TopicUpdateDto dto)
        {
            Topic topic = await CheckIdAsync(id);
            if (topic.Name.ToLower() == dto.Name.ToLower())
                throw new TopicIsExistException();
            
            #region IsNameExistAsync
            //await IsNameExistAsync(dto.Name);
            #endregion

            _mapper.Map(dto, topic);
            await _repo.SaveAsync();
        }

        public async Task RemoveAsync(int? id, params string[] includes)
        {
            _repo.Remove(await CheckIdAsync(id,false, includes));
            await _repo.SaveAsync();
        }

        public async Task SoftRemoveAsync(int? id, params string[] includes)
        {
            var item = await CheckIdAsync(id);
            item.IsDeleted = true;
            await _repo.SaveAsync();
        }

        public async Task<Topic> CheckIdAsync(int? id, bool isTrack = false,params string[] includes)
        {
            if (id <= 1 || id == null)
                throw new ArgumentOutOfRangeException();
            Topic? item = await _repo.GetByIdAsync(id, isTrack, includes);
            if (item == null)
                throw new NotFoundException<Topic>();
            return item;
        }

        #region Topic Name IsUnique
        //async Task IsNameExistAsync(string name)
        //{
        //    if (await _repo.IsExistAsync(x => x.Name.ToLower() == name.ToLower()))
        //        throw new TopicIsExistException();
        //}
        #endregion


        public async Task<bool> IsExistAsync(int? id)
         => await _repo.IsExistAsync(x => x.Id == id);
    }
}
