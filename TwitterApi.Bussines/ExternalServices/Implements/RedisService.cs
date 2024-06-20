using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TwitterApi.Bussines.Dtos.RedisDtos;

namespace TwitterApi.Bussines.ExternalServices.Implements
{
    public class RedisService : IRedisService
    {
        Lazy<ConnectionMultiplexer> masterConnection { get; set; }
        ConfigurationOptions sentinelConfiguration { get; } = new()
        {
            AbortOnConnectFail = false,
            CommandMap = CommandMap.Sentinel
        };

        public async Task<IDatabase> GetDatabaseAsync(RedisOption option)
        {
            foreach (var item in option.Sentinels)
            {
                sentinelConfiguration.EndPoints.Add(item);
            }
            await RedisConnectionAsync(option);
            return masterConnection.Value.GetDatabase();
        }

        private async Task RedisConnectionAsync(RedisOption option)
        {
            using(ConnectionMultiplexer sentinelConnection = await ConnectionMultiplexer.SentinelConnectAsync(sentinelConfiguration))
            {
                EndPoint masterEndPoint = await GetEndPointAsync(sentinelConnection,option.MasterName);
                string localMasterIp = GetLocalMasterIp(masterEndPoint);
                masterConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.ConnectAsync(localMasterIp).Result);
            }
        }

        private async Task<EndPoint> GetEndPointAsync(IConnectionMultiplexer sentinelConnection, string masterName)
        {
            foreach (EndPoint endPoint in sentinelConnection.GetEndPoints())
            {
                IServer server = sentinelConnection.GetServer(endPoint);
                if (!server.IsConnected)
                    continue;                
                return await server.SentinelGetMasterAddressByNameAsync(masterName);
            }

            //todo: Master NAme Excetion
            throw new Exception($"Failed to find master endpoint for Redis Sentinel with master name: {masterName}");
        }

        private string GetLocalMasterIp(EndPoint masterEndPoint)
        {

            return masterEndPoint.ToString() switch
            {
                "172.18.0.5:6379" => "localhost:1456",
                "172.18.0.6:6379" => "localhost:1455",
                "172.18.0.7:6379" => "localhost:1454",
                "172.18.0.8:6379" => "localhost:1453",
                _ => throw new Exception($"Unsupported master endpoint: {masterEndPoint}")
            };
        }
    }
}
