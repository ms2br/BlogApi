using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using TwitterApi.Bussines.Dtos.BlogDtos;
using TwitterApi.Bussines.Dtos.FileDtos;
using TwitterApi.Bussines.Dtos.TopicDtos;
using TwitterApi.Bussines.Exceptions.TopicException;
using TwitterApi.Core.Entities;
using TwitterApi.Core.Entities.Identity;
using TwitterApi.DAL.Repositories.Interfaces;

namespace TwitterApi.Bussines.Services.Implements
{
    public class PostService : IPostService
    {
        IMapper _mapper { get; }
        IPostRepository _repo { get; }
        IFileService _fileService { get; }
        ITopicService _topicService { get; }
        IHttpContextAccessor _httpContextAccessor { get; set; }
        string _userId { get; }

        public PostService(IMapper mapper,
            IPostRepository repo,
            IHttpContextAccessor httpContextAccessor,
            UserManager<AppUser> um,
            IFileService fileService,
            ITopicService topicService)
        {
            _mapper = mapper;
            _repo = repo;
            _httpContextAccessor = httpContextAccessor;
            _userId = checkIsAuthenticated() ? um.GetUserId(_httpContextAccessor.HttpContext?.User) : throw new NullReferenceException();
            _fileService = fileService;
            _topicService = topicService;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(params string[] includes) where T : class
        => _mapper.Map<IEnumerable<T>>(await _repo.GetAllAsync(true, includes));
        
        public async Task<T> GetByIdAsync<T>(int? id, params string[] includes) where T : class
         => _mapper.Map<T>(await CheckIdAsync(id, true, includes));
                
        public async Task CreateAsync(PostCreateDto dto)
        {
            var item = _mapper.Map<Post>(dto);
            item.UserId = _userId;
            if (dto.FormFiles != null)
                foreach (var file in dto.FormFiles)
                    item.Files.Add(await _fileService.CreateAsync(file));
            if(!Enumerable.SequenceEqual((await _topicService.GetAllAsync<TopicDetailDto>()).Select(x=> x.Id), dto.TopicIds))
                throw new TopicIsExistException();
            foreach (int topicId in dto.TopicIds)
                item.Topics.Add(new PostTopic { TopicId = topicId});

            await _repo.CreateAsync(item);
            await _repo.SaveAsync();
        }

        public async Task UpdateAsync(int? id,PostUpdateDto updateDto,params string[] includes)
        {
            Post blog = await CheckIdAsync(id, false, includes);
            var item = _mapper.Map<PostUpdateDetailDto>(blog);
            item.Content = updateDto.Content;
            await updateTopicAsync(updateDto,item);
            if (updateDto.FormFiles != null)
                foreach (var file in updateDto.FormFiles)
                    item.Files.Add(await _fileService.CreateAsync(file));   
            _mapper.Map(item, blog);
            await _repo.SaveAsync();
        }

        public async Task RemoveAsync(int? id, params string[] includes)
        {
            Post post = await CheckIdAsync(id,false,includes);
            checkIsAuthorization(post.UserId);
            foreach (PostTopic topic in post.Topics)
                post.Topics.Remove(topic);
            if(post.Files.Count() != 0 || post.Files != null)
                foreach (var file in post.Files)
                    await _fileService.RemoveAsync(file);
            _repo.Remove(post);
            await _repo.SaveAsync();
        }

        public async Task SoftRemoveAsync(int? id, params string[] includes)
        {
            Post post = await CheckIdAsync(id,false, includes);
            checkIsAuthorization(post.UserId);
            if (post.Files.Count() != 0 || post.Files != null)
                foreach (var file in post.Files)
                    await _fileService.RemoveAsync(file);
            post.IsDeleted = true;
            await _repo.SaveAsync();
        } 

        public async Task<Post> CheckIdAsync(int? id, bool noTracking, params string[] includes)
        {
            if (id < 1 || id == null)
                throw new ArgumentOutOfRangeException();
            Post? item = await _repo.GetByIdAsync(x=> x.Id == id, noTracking, includes);
            checkIsAuthorization(item.UserId);
            if (item == null)
                throw new NotFoundException<Post>();
            return item;
        }

        public async Task<bool> IsExistAsync(int? id)
        => await _repo.IsExistAsync(x => x.Id == id);
        
        public async Task UpdateImgFilesAsync(int? blogId,int? fileId,FileUpdateDto file,params string[] includes)
        {

            if (fileId <= 0 || fileId == null)
                throw new ArgumentOutOfRangeException();
            Post blog = await CheckIdAsync(blogId, false, includes);
            if (blog.UserId != _userId)
                throw new AuthenticationException();
            var item = _mapper.Map<PostUpdateDetailDto>(blog);
            await _fileService.UpdateAsync(file.File, item, fileId);
            await _repo.SaveAsync();
        }

        public async Task RemoveImgFilesAsync(int? blogId, int? fileId, params string[] includes)
        {

            if (fileId <= 0 || fileId == null)
                throw new ArgumentOutOfRangeException();
            Post blog = await CheckIdAsync(blogId, false, includes);
            if (blog.UserId != _userId)
                throw new AuthenticationException();
            var blogDto = _mapper.Map<PostUpdateDetailDto>(blog);
            await _fileService.RemoveAsync(blogDto, fileId);
            await _repo.SaveAsync();
        }

        async Task<PostUpdateDetailDto> updateTopicAsync(PostUpdateDto updateDto, PostUpdateDetailDto blog)
        {
            await checkIsTopicIdsAsync(updateDto.TopicIds);
            if (!Enumerable.SequenceEqual(updateDto.TopicIds, blog.Topics.Select(x => x.TopicId)))
                foreach (int topicId in updateDto.TopicIds)
                    blog.Topics.Add(new PostTopic { TopicId = topicId });
            return blog;
        }
       
        async Task checkIsTopicIdsAsync(IEnumerable<int>? topicIds)
        {
            foreach (var id in topicIds)
                if (!await _topicService.IsExistAsync(id))
                    throw new TopicIsExistException();
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
