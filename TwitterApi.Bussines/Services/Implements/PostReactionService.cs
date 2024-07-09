using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterApi.Bussines.Dtos.PostReactionDtos;
using TwitterApi.Core.Entities;
using TwitterApi.Core.Entities.Identity;
using TwitterApi.DAL.Repositories.Interfaces;

namespace TwitterApi.Bussines.Services.Implements
{
    public class PostReactionService : IPostReactionService
    {
        IMapper _mapper { get; }
        IPostReactionRepository _repo {get; }
        IHttpContextAccessor _httpContextAccessor { get; }
        IPostRepository _postRepo { get; }
        string _userId { get; }

        public PostReactionService(IMapper mapper,
            IPostReactionRepository repo,
            IHttpContextAccessor httpContextAccessor,
            UserManager<AppUser> um,
            IPostRepository postRepo)
        {
            _mapper = mapper;
            _repo = repo;
            _httpContextAccessor = httpContextAccessor;
            _userId = checkIsAuthenticated() ? um.GetUserId(_httpContextAccessor.HttpContext.User) : throw new NullReferenceException();
            _postRepo = postRepo;
        }


        public async Task CreateAsync(PRCreateDto dto)
        {
            PostReaction item = _mapper.Map<PostReaction>(dto);
            item.AppUserId = _userId;            
            await _repo.CreateAsync(item);
            await _repo.SaveAsync();
        }

        public Task<IEnumerable<T>> GetAllAsync<T>(params string[] includes) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync<T>(int? id, params string[] includes) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int? id, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public Task SoftRemoveAsync(int? id, params string[] includes)
        {
            throw new NotImplementedException();
        }

        async Task<PostReaction> IGenericService<PostReaction, PRCreateDto>.CheckIdAsync(int? id, bool isTrack, params string[] includes)
        {
            throw new NotImplementedException();
        }

        bool checkIsAuthenticated()
        => _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;

        void checkIsAuthorization(string userId)
        {
            if (_userId != userId)
                throw new AuthenticationException();
        }
    }
}
