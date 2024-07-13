using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterApi.Bussines.Dtos.PostReactionDtos;
using TwitterApi.Bussines.Exceptions.PostReactionException;
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
        IPostService _postService { get; }
        string _userId { get; }

        public PostReactionService(IMapper mapper,
            IPostReactionRepository repo,
            IHttpContextAccessor httpContextAccessor,
            UserManager<AppUser> um,
            IPostService postService)
        {
            _mapper = mapper;
            _repo = repo;
            _httpContextAccessor = httpContextAccessor;
            _userId = checkIsAuthenticated() ? um.GetUserId(_httpContextAccessor.HttpContext.User) : throw new NullReferenceException();
            _postService = postService;
        }


        public async Task CreateAsync(PRCreateDto dto)
        {
            if (!await _postService.IsExistAsync(dto.PostId))
                throw new NotFoundException<Post>();
            
            if(await IsExistAsync(dto.PostId))
                throw new PostReactionIsExistException();

            PostReaction item = _mapper.Map<PostReaction>(dto);
            item.AppUserId = _userId;
            await _repo.CreateAsync(item);
            await _repo.SaveAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(params string[] includes) where T : class
        => _mapper.Map<IEnumerable<T>>(await _repo.GetAllAsync(true, includes));

        public async Task<T> GetByIdAsync<T>(int? postId, params string[] includes) where T : class
        => _mapper.Map<T>(await CheckIdAsync(postId, true,includes));

        public async Task<PostReaction> CheckIdAsync(int? postId, bool noTracking, params string[] includes)
        {
            if (postId < 1 || postId == null)
                throw new NotFoundException<Post>();
            if (!await _postService.IsExistAsync(postId))
                throw new NotFoundException<Post>();                        
            
            PostReaction? item = await _repo.GetByIdAsync(x=> x.PostId == postId && x.AppUserId == _userId, noTracking, includes);
            
            checkIsAuthorization(item.AppUserId);
            if (item == null)
                throw new NotFoundException<PostReaction>();            
            return item;
        }

        public async Task RemoveAsync(int? postId, params string[] includes)
        {
            _repo.Remove(await CheckIdAsync(postId, false, includes));
            await _repo.SaveAsync();
        }

        public async Task SoftRemoveAsync(int? postId, params string[] includes)
        {
            PostReaction postReaction = await CheckIdAsync(postId,false,includes);
            postReaction.IsDeleted = true;
            await _repo.SaveAsync();
        }

        public async Task<bool> IsExistAsync(int? postId)
        => await _repo.IsExistAsync(x => x.AppUserId == _userId && postId == x.PostId);

        public async Task UpdateAsync(int? postId,PRUpdateDto dto)
        {
            PostReaction postReaction = await CheckIdAsync(postId,false); 
            _mapper.Map(dto,postReaction);
            await _repo.SaveAsync();
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
