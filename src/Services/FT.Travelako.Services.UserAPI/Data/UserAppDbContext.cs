using FT.Travelako.Services.UserAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FT.Travelako.Services.UserAPI.Data
{
    public class UserAppDbContext : DbContext
    {
        public UserAppDbContext(DbContextOptions<UserAppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
