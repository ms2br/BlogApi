using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;
using TwitterApi.Bussines.Dtos.RedisDtos;
using TwitterApi.Bussines.Dtos.UserDtos;
using TwitterApi.Bussines.ExternalContext.Implements;
using TwitterApi.Bussines.ExternalContext.Interfaces;
using TwitterApi.Bussines.ExternalServices.Implements;
using TwitterApi.Bussines.Services.Implements;
using TwitterApi.DAL.Repositories.Implements;
using TwitterApi.DAL.Repositories.Interfaces;
namespace TwitterApi.Bussines
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection repo)
        {
            repo.AddScoped<ITopicRepository, TopicRepository>();
            repo.AddScoped<IFileRepository, FileRepository>();
            repo.AddScoped<IPostRepository, PostRepository>();
            repo.AddScoped<IPostReactionRepository, PostReactionRepository>();
            return repo;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IBlackListService, BlackListService>();
            services.AddScoped<IPostReactionService, PostReactionService>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<IRedisContext, RedisContext>();
            return services;
        }

        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {           
            services.AddRepositories();
            services.AddServices();
            services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<RegisterDtoValidator>());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    
    
    }
}
