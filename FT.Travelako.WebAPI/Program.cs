using FT.Travelako.Base.BaseUtility;
using FT.Travelako.WebAPI.Services;
using FT.Travelako.WebAPI.Services.IServices;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Config Ocelot
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("ocelot.json")
    .Build();

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<ICouponService, CouponService>();
StaticData.BaseCouponAPI = builder.Configuration["ServiceUrls:CouponAPI"];

builder.Services.AddScoped<IGatewayService, GatewayService>();
builder.Services.AddScoped<ICouponService, CouponService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOcelot();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseOcelot();

app.UseAuthorization();

app.MapControllers();

app.Run();
