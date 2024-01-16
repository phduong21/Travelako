using AutoMapper;
using FT.Travelako.Services.UserAPI;
using FT.Travelako.Services.UserAPI.Data;
using Microsoft.EntityFrameworkCore;
using FT.Travelako.Service.Core.ServiceDiscovery;
using FT.Travelako.Services.UserAPI.Installer;
using FT.Travelako.Services.UserAPI.Repositories;
using System.Text.Json.Serialization;
using MassTransit;
using FT.Travelako.Services.UserAPI.EventBusConsumer;
using FT.Travelako.EventBus.Messages.Common;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddConsul(builder.Configuration.GetServiceConfig());
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<UserAppDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("UserAuthenDB"));
});
builder.Services.AddCors();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
IMapper mapper = MappingSettings.RegisterMap().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add MassTransit
builder.Services.AddMassTransit(config => {

    config.AddConsumer<TravelConsumer>();
    config.UsingRabbitMq((ctx, cfg) => {
        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
        //cfg.ConfigureEndpoints(ctx, new KebabCaseEndpointNameFormatter("Coupon", false));
        cfg.ReceiveEndpoint(EventBusConstants.TravelQueue, c => {
            c.ConfigureConsumer<TravelConsumer>(ctx);
        });
    });
});

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(opt => { opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); }); ;
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
