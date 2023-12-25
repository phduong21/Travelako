using FT.Travelako.Services.TravelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FT.Travelako.Services.TravelAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //public DbSet<Travel> Travels { get; set; } 
    }
}
