using FT.Travelako.Services.TravelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FT.Travelako.Services.TravelAPI.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
			.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			.AddJsonFile("appsettings.json")
			.Build();
			optionsBuilder.UseSqlServer(configuration.GetConnectionString("TravelDB"));
		}

		public DbSet<Travel> Travels { get; set; }
	}
}