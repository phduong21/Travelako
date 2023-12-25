using FT.Travelako.Services.BookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FT.Travelako.Services.BookingAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //public DbSet<Booking> Bookings { get; set; } 
    }
}
