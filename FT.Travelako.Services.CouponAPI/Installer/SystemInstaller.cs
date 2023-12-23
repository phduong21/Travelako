using Microsoft.OpenApi.Models;

namespace FT.Travelako.Services.CouponAPI.Installer
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
