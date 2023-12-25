using FT.Travelako.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace FT.Travelako.Common.Database
{
    public class TravelkoContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCoupon> UserCoupons { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LUPIN;Database=Travelako;Trusted_Connection=True;TrustServerCertificate=True;");
            //UseSqlServer(config.GetConnectionString("optimumDB"))
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne<Role>(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<User>()
            .HasOne<UserCoupon>(u => u.UserCoupon)
            .WithMany(uc => uc.Users)
            .HasForeignKey(u => u.UserCouponId);

            modelBuilder.Entity<Coupon>()
            .HasOne<UserCoupon>(u => u.UserCoupon)
            .WithMany(uc => uc.Coupons)
            .HasForeignKey(u => u.UserCouponId);

            modelBuilder.Entity<Booking>()
            .HasOne<User>(b => b.User)
            .WithMany(u => u.Bookings)
            .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Booking>()
            .HasOne<Travel>(b => b.Travel)
            .WithMany(t => t.Bookings)
            .HasForeignKey(b => b.TravelId);
        }
    }
}