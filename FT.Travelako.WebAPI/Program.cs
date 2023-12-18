using FT.Travelako.WebAPI.Services;
using FT.Travelako.WebAPI.Services.IServices;
using FT.Travelako.WebAPI.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
