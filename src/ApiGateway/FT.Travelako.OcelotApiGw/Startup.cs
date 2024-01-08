using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Ocelot.Cache.CacheManager;
using Ocelot.Provider.Polly;
using FT.Travelako.OcelotApiGw.Installer;
using FT.Travelako.OcelotApiGw.Configuration;

namespace FT.Travelako.OcelotApiGw
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOcelot()
                .AddConsul()
                .AddCacheManager(x =>
                {
                    x.WithDictionaryHandle();
                })
                .AddPolly();
            services.InstallerServicesInAssembly(Configuration);
            services.Configure<AppSettingsConfiguration>(Configuration.GetSection("AppSettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Api Gateway Running!");
                });
            });
            app.UseAuthentication();
            app.UseOcelot().Wait();


        }
    }
}
