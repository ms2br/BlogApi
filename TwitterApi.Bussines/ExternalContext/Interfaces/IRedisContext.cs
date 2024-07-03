using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterApi.Bussines.Dtos.RedisDtos;

namespace TwitterApi.Bussines.ExternalContext.Interfaces
{
    public interface IRedisContext
    {
        IDatabase Database { get; protected set; }
        Task GetDatabaseAsync(RedisOption option,int dbNumber = 0);
    }
}
