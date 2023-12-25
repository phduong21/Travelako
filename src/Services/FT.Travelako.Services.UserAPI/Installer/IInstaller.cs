using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FT.Travelako.Services.UserAPI.Installer
{
    public interface IInstaller
    {
        void InstallerServicesInAssembly(IServiceCollection service, IConfiguration configuration);
    }
}
