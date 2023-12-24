using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using FT.Travelako.OcelotApiGw.Configuration;
using System.Text;
using StackExchange.Redis;
using Microsoft.Extensions.DependencyInjection;
using FT.Travelako.OcelotApiGw.Service;
using Ocelot.Values;

namespace FT.Travelako.OcelotApiGw.Installer
{
    public class AuthenticationInstaller : IInstaller
    {
        public void InstallerServicesInAssembly(IServiceCollection service, IConfiguration configuration)
        {
            var authenConfiguration = new AppSettingsConfiguration();
            configuration.GetSection("AppSettings").Bind(authenConfiguration);


            service.AddSingleton<IJwtTokenService,JwtTokenService>();

            service.AddAuthentication(
                opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
             .AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    // auto gen token
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // sign to token
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenConfiguration.SecretKey)),

                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
