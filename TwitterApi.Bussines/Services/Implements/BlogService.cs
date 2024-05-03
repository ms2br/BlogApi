using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TwitterApi.Bussines.Dtos.BlogDtos;
using TwitterApi.Bussines.Dtos.TopicDtos;
using TwitterApi.Bussines.Exceptions.TopicException;
using TwitterApi.Core.Entities;
using TwitterApi.Core.Entities.Identity;
using TwitterApi.DAL.Repositories.Interfaces;

namespace TwitterApi.Bussines.Services.Implements
{
    public class BlogService : IBlogService
    {
        IMapper _mapper { get; }
        IBlogRepository _repo { get; }
        IFileService _fileService { get; }
        ITopicService _topicService { get; }
        IHttpContextAccessor _httpContextAccessor { get; set; }
        UserManager<AppUser> _um { get; set; }
        string _userId { get; }

        public BlogService(IMapper mapper,
            IBlogRepository repo,
            IHttpContextAccessor httpContextAccessor,
            UserManager<AppUser> um,
            IFileService fileService,
            ITopicService topicService)
        {
            _mapper = mapper;
            _repo = repo;
            _httpContextAccessor = httpContextAccessor;
            _um = um;
            _userId = checkIsAuthenticated() ? _um.GetUserId(_httpContextAccessor.HttpContext?.User) : throw new NullReferenceException();
            _fileService = fileService;
            _topicService = topicService;
        }

        public async Task CreateAsync(BlogCreateDto dto)
        {
            var item = _mapper.Map<Blog>(dto);
            item.UserId = _userId;
            if (dto.FormFiles != null)
                foreach (var file in dto.FormFiles)
                    item.Files.Add(await _fileService.CreateAsync(file));
            if(!Enumerable.SequenceEqual((await _topicService.GetAllAsync<TopicDetailDto>()).Select(x=> x.Id), dto.TopicIds))
                throw new TopicIsExistException();
            foreach (int topicId in dto.TopicIds)
                item.Topics.Add(new BlogTopic { TopicId = topicId});

            await _repo.CreateAsync(item);
            await _repo.SaveAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(params string[] includes) where T : class
        => _mapper.Map<IEnumerable<T>>(await _repo.GetAllAsync(false, includes));

        public async Task<T> GetByIdAsync<T>(int? id, params string[] includes) where T : class
        => _mapper.Map<T>(await CheckIdAsync(id, true, includes));
       
        public async Task RemoveAsync(int? id)
        {
            _repo.Remove(await CheckIdAsync(id));
        }

        public Task SoftRemoveAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<Blog> CheckIdAsync(int? id, bool isTrack = true, params string[] includes)
        {
            if (id <= 1 || id == null)
                throw new ArgumentOutOfRangeException();
            Blog? item = await _repo.GetByIdAsync(id, isTrack, includes);
            if (item == null)
                throw new NotFoundException<Blog>();
            return item;
        }

        bool checkIsAuthenticated()
        => _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;

        public async Task<bool> IsExistAsync(int? id)
        => await _repo.IsExistAsync(x => x.Id == id);
    }
}
