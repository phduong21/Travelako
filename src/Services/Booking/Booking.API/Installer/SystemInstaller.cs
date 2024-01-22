using Microsoft.OpenApi.Models;
using Booking.Infrastructure;
using Booking.Application;
using FT.Travelako.Service.Core.ServiceDiscovery;
using MassTransit;
using Consul;
using Polly;
using FT.Travelako.EventBus.Messages.Common;

namespace Booking.API.Installer
{
    public class SystemInstaller : IInstaller
    {
        public void InstallerServicesInAssembly(IServiceCollection services, IConfiguration configuration)
        {
            services.AddConsul(configuration.GetServiceConfig());
            services.AddApplicationServices(configuration);
            services.AddInfrastructureServices(configuration);
            services.AddHttpContextAccessor();

            // General Configuration
            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Booking.API", Version = "v1" });
            });

            services.AddEndpointsApiExplorer();
        }
    }
}
