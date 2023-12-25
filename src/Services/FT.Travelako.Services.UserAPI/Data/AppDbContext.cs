using FT.Travelako.Services.UserAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FT.Travelako.Services.UserAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //public DbSet<Travel> Travels { get; set; } 
    }
}
