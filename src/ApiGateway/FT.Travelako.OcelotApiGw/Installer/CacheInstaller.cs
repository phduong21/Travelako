using FT.Travelako.OcelotApiGw.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using FT.Travelako.OcelotApiGw.Service;

namespace FT.Travelako.OcelotApiGw.Installer
{
    public class CacheInstaller : IInstaller
    {
        public void InstallerServicesInAssembly(IServiceCollection service, IConfiguration configuration)
        {
            var redisConfiguration = new RedisConfiguration();
            configuration.GetSection("RedisConfiguration").Bind(redisConfiguration);

            service.AddSingleton(redisConfiguration);

            if (!redisConfiguration.Enabled) return;

            service.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(redisConfiguration.ConnectionString));
            service.AddStackExchangeRedisCache(option => option.Configuration = redisConfiguration.ConnectionString);
            service.AddSingleton<IResponseCacheService, ResponseCacheService>();
        }
    }
}
