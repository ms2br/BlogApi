using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using TwitterApi.Bussines.Dtos.BlogDto;
using TwitterApi.Core.Entities;
using TwitterApi.Core.Entities.Identity;
using TwitterApi.DAL.Repositories.Interfaces;

namespace TwitterApi.Bussines.Services.Implements
{
    public class BlogService : IBlogService
    {
        IMapper _mapper { get; }
        IBlogRepository _repo { get; }
        IHttpContextAccessor _httpContextAccessor { get; set; }
        UserManager<AppUser> _um { get; set; }
        string _userId { get; }
        public BlogService(IMapper mapper,
            IBlogRepository repo,
            IHttpContextAccessor httpContextAccessor,
            UserManager<AppUser> um)
        {
            _mapper = mapper;
            _repo = repo;
            _httpContextAccessor = httpContextAccessor;
            _um = um;
            _userId = um.GetUserId(_httpContextAccessor.HttpContext.User) ?? throw new NullReferenceException();
        }


        public async Task CreateAsync(BlogCreateDto dto)
        {
            var item = _um.GetUserId(_httpContextAccessor.HttpContext.User);
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync<T>(int? id) where T : class
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task SoftRemoveAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<Blog> CheckIdAsync(int? id, bool isTrack = true)
        {
            return null;
        }
    }
}
