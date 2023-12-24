using Microsoft.OpenApi.Models;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Provider.Polly;
using Ocelot.Provider.Consul;


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
        }
    }
}
