namespace FT.Travelako.Services.Authentication.Installer
{
    public static class InstallerExtension
    {
        public static void InstallerServicesInAssembly(this IServiceCollection service, IConfiguration configuration)
        {
            var installer = typeof(Program).Assembly.ExportedTypes.Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface
            && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            installer.ForEach(installer => installer.InstallerServicesInAssembly(service, configuration));
        }
    }
}
