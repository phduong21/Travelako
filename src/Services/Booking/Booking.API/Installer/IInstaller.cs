using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.API.Installer
{
    public interface IInstaller
    {
        void InstallerServicesInAssembly(IServiceCollection service, IConfiguration configuration);
    }
}
