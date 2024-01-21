using FT.Travelako.Services.Authentication.Model;
using Microsoft.EntityFrameworkCore;

namespace FT.Travelako.Services.Authentication.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
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
        public AppDbContext() { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>()
                        .HasQueryFilter(p => p.IsDeleted == false);

        }
    }
}
