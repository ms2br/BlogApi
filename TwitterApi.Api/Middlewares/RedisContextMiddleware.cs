using Microsoft.Extensions.Options;
using TwitterApi.Bussines.Dtos.RedisDtos;
using TwitterApi.Bussines.ExternalContext.Interfaces;

namespace TwitterApi.Api.Middlewares
{
    public static class RedisContextMiddleware
    {
        static IRedisContext redisContext { get; set; }

        public static IApplicationBuilder UseRedisConnection(this WebApplication webApplication)
        {            
            webApplication.Use(async (context, next) =>
            {
                using (IServiceScope scope = context.RequestServices.CreateScope())
                {
                    redisContext = scope.ServiceProvider.
                    GetRequiredService<IRedisContext>();
                    IOptionsMonitor<RedisOption>? option = scope.ServiceProvider.
                    GetRequiredService<IOptionsMonitor<RedisOption>>();
                    if (redisContext.Database == null)
                        OnOptionsChanged(option.CurrentValue);
                    else
                        option.OnChange(OnOptionsChanged);
                }
                await next();
            });
            return webApplication;
        }

        public static void OnOptionsChanged(RedisOption option)
        {
            redisContext.GetDatabaseAsync(option).Wait();
        }
    }
}
