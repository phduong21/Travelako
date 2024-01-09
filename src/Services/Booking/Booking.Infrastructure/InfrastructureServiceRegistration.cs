using Booking.Application.Contracts.Persistence;
using Booking.Application.Models;
using Booking.Domain.Entities;
using Booking.Infrastructure.Mail;
using Booking.Infrastructure.Persistence;
using Booking.Infrastructure.Repositories;
using FT.Travelako.Common.Database;
using FT.Travelako.Common.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookingContext>(opts =>
            {
                opts.UseSqlServer(configuration.GetConnectionString("Default"));
            });
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IOrderRepository, OrderRepository>();

            //services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            //services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
