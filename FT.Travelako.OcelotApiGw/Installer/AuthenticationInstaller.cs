using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using FT.Travelako.OcelotApiGw.Configuration;
using System.Text;

namespace FT.Travelako.OcelotApiGw.Installer
{
    public class AuthenticationInstaller : IInstaller
    {
        public void InstallerServicesInAssembly(IServiceCollection service, IConfiguration configuration)
        {
            var authenConfiguration = new AppSettingsConfiguration();
            configuration.GetSection("AppSettings").Bind(authenConfiguration);

            var secretKey = authenConfiguration.SecretKey;
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
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
                    IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
