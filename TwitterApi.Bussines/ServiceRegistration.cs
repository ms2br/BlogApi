using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
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
            repo.AddScoped<IBlogRepository, BlogRepository>();
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
            services.AddScoped<IBlogService, BlogService>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
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
