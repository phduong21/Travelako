using FT.Travelako.Service.Core.ServiceDiscovery;
using FT.Travelako.Services.Authentication.Installer;
using Microsoft.EntityFrameworkCore;
using FT.Travelako.Services.Authentication.Data;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddConsul(builder.Configuration.GetServiceConfig());
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<AppDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("UserAuthenDB"));
});
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
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
