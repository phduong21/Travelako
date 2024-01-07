using FT.Travelako.Services.UserAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FT.Travelako.Services.UserAPI.Data
{
    public class UserAppDbContext : DbContext
    {
        public UserAppDbContext(DbContextOptions<UserAppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("UserAuthenDB");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public UserAppDbContext() { }
        public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
    }
}
