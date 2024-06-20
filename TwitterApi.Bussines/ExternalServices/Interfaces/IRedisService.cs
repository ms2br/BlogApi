using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterApi.Bussines.Dtos.RedisDtos;

namespace TwitterApi.Bussines.ExternalServices.Interfaces
{
    public interface IRedisService
    {
        Task<IDatabase> GetDatabaseAsync(RedisOption option);
    }
}
