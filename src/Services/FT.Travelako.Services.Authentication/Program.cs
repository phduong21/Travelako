using FT.Travelako.Service.Core.ServiceDiscovery;
using FT.Travelako.Services.Authentication.Installer;
using FT.Travelako.Services.Authentication.Model;
using FT.Travelako.Services.Authentication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddConsul(builder.Configuration.GetServiceConfig());
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddJsonFile("appsettings.json", false, true)
                    .AddEnvironmentVariables();
ConfigurationManager configuration = builder.Configuration;
builder.Services.InstallerServicesInAssembly(configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/login", [AllowAnonymous] ([FromBody] LoginModel request, HttpContext http, IJwtTokenService tokenService) => new ApiResponse
{
    Success = true,
    Message = "Authenticate success",
    Data = tokenService.GenerateAuthToken(request)
}).WithName("Login");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
