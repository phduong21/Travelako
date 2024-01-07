using FT.Travelako.Common.Entities;
using FT.Travelako.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace FT.Travelako.Services.UserAPI.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public string? Personalization { get; set; }
        public virtual Role Role { get; set; }

        // public Guid UserCouponId { get; set; }
        // public UserCoupon UserCoupon { get; set; }
        // public ICollection<Booking> Bookings { get; set; }
    }
}
