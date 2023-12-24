using System.ComponentModel.DataAnnotations;

namespace FT.Travelako.Services.CouponAPI.Models
{
    public class Coupon
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
    }
}
