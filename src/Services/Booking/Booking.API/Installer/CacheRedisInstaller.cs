using FT.Travelako.Common.Configuration;

namespace Booking.API.Installer
{
    public class CacheRedisInstaller : IInstaller
    {
        public void InstallerServicesInAssembly(IServiceCollection service, IConfiguration configuration)
        {


            var authenConfiguration = new AppSettingsConfiguration();
            configuration.GetSection("AppSettings").Bind(authenConfiguration);
            service.AddStackExchangeRedisCache(opts =>
            {
                opts.Configuration = authenConfiguration.RedisConnection;
                opts.InstanceName = "Authenc_Cache";
            });
        }
    }
}
