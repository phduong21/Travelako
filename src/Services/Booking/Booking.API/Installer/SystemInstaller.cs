using Microsoft.OpenApi.Models;
using Booking.Infrastructure;
using Booking.Application;
using FT.Travelako.Service.Core.ServiceDiscovery;
using MassTransit;

namespace Booking.API.Installer
{
    public class SystemInstaller : IInstaller
    {
        public void InstallerServicesInAssembly(IServiceCollection services, IConfiguration configuration)
        {
            services.AddConsul(configuration.GetServiceConfig());
            services.AddApplicationServices();
            services.AddInfrastructureServices(configuration);
            services.AddHttpContextAccessor();

            // MassTransit-RabbitMQ Configuration
            services.AddMassTransit(config => {
                config.UsingRabbitMq((ctx, cfg) => {
                    cfg.Host(configuration["EventBusSettings:HostAddress"]);
                });
            });

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
