using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterApi.Bussines.Dtos.RedisDtos;
using TwitterApi.Bussines.ExternalContext.Implements;
using TwitterApi.Bussines.ExternalContext.Interfaces;

namespace TwitterApi.Bussines.ExternalServices.Implements
{
    public class BlackListService : IBlackListService
    {
        IRedisContext _redisContext { get; }
        IConfiguration _configuration { get; }
        public BlackListService(
            IRedisContext redisContext,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _redisContext = redisContext;
        }

        public async Task SetAsync(string token)
        {
            if (!await TokenCheckAsync(token))
            {
                TimeSpan timeSpan = new TimeSpan(Convert.ToInt32(_configuration["Token:LifeSpan"]), 0, 0);
                await _redisContext.Database.StringSetAsync(token, token, timeSpan,true);
            }
        }

        public async Task<bool> TokenCheckAsync(string token)
        => await _redisContext.Database.KeyExistsAsync(token);
    }
}
