using AutoMapper;
using FT.Travelako.Services.BookingAPI;
using FT.Travelako.Services.BookingAPI.Data;
using FT.Travelako.Services.BookingAPI.Installer;
using Microsoft.EntityFrameworkCore;
using FT.Travelako.Service.Core.ServiceDiscovery;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddConsul(builder.Configuration.GetServiceConfig());
builder.Services.AddHttpContextAccessor();
//builder.Services.AddDbContext<AppDbContext>(opts =>
//{
//    opts.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
//});
builder.Services.AddCors();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
IMapper mapper = MappingSettings.RegisterMap().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
