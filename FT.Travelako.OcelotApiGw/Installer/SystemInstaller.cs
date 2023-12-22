using Microsoft.OpenApi.Models;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;


namespace FT.Travelako.OcelotApiGw.Installer
{
    public class SystemInstaller : IInstaller
    {
        public void InstallerServicesInAssembly(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Microservices demo", Version = "v1" });
            });

            services.AddEndpointsApiExplorer();
            services.AddOcelot(configuration).AddCacheManager(x => x.WithDictionaryHandle());
        }
    }
}
