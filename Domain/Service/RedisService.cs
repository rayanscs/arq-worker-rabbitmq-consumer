using ARQ.RabbitMQ.Consumer.Worker.Domain.Interface.Service;
using ARQ.RabbitMQ.Consumer.Worker.Domain.Model.Configs;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace ARQ.RabbitMQ.Consumer.Worker.Domain.Service
{
    public class RedisService : IRedisService
    {
        private readonly ConnectionMultiplexer redisClient;
        private readonly int _dbRedis;
        private readonly RedisConfig _redisConfig;

        public RedisService(IOptions<RedisConfig> redisConfig, ConnectionMultiplexer manager, IConfiguration configuration)
        {
            redisClient = manager;
            _redisConfig = redisConfig.Value;
            _dbRedis = Convert.ToInt32(_redisConfig.RedisDBNumber);
        }

        public string GetValue(string key)
        {
            try
            {
                var database = redisClient.GetDatabase(_dbRedis);
                var result = database.StringGet(key);

                if (result == RedisValue.Null)
                {
                    result = string.Empty;
                    return result;
                }

                return result.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public void SetValueAsync<T>(string key, T value, TimeSpan? expiryCache = null)
        {
            try
            {
                var database = redisClient.GetDatabase(_dbRedis);

                if (expiryCache is null)
                    database.StringSet(key, JsonConvert.SerializeObject(value));
                else
                    database.StringSet(key, JsonConvert.SerializeObject(value), expiryCache);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RemoveKey(string key)
        {
            try
            {
                var database = redisClient.GetDatabase(_dbRedis);
                database.KeyDelete(key);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
