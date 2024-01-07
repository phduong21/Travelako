﻿using FT.Travelako.Common.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FT.Travelako.Services.UserAPI.Installer
{
    public class AuthenticationInstaller : IInstaller
    {
        public void InstallerServicesInAssembly(IServiceCollection service, IConfiguration configuration)
        {


            var authenConfiguration = new AppSettingsConfiguration();
            configuration.GetSection("AppSettings").Bind(authenConfiguration);
            service.AddSingleton<IAppSettingsConfiguration, AppSettingsConfiguration>(x => authenConfiguration);
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
                     ValidateLifetime = true,
                     ClockSkew = TimeSpan.Zero
                 };
             });
        }
    }
}
