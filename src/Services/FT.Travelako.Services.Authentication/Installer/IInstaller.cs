using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FT.Travelako.Services.Authentication.Installer
{
    public interface IInstaller
    {
        void InstallerServicesInAssembly(IServiceCollection service, IConfiguration configuration);
    }
}
