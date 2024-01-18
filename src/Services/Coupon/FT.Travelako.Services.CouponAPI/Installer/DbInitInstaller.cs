using Coupon.Application.Contracts.Persistence;
using FT.Travelako.Common.Repositories;
using FT.Travelako.Services.CouponAPI.Repository;
using Coupon.Application;

namespace FT.Travelako.Services.CouponAPI.Installer
{
    public class DbInitInstaller : IInstaller
    {
        public void InstallerServicesInAssembly(IServiceCollection service, IConfiguration configuration)
        {
            service.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            service.AddScoped<ICouponRepository, CouponRepository>();
            service.AddScoped<ICouponUserRepository, CouponUserRepository>();
            service.AddApplicationServices();
        }
    }
}
