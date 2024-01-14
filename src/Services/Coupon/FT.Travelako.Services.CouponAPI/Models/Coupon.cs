using System.ComponentModel.DataAnnotations;

namespace FT.Travelako.Services.CouponAPI.Models
{
    public class Coupon
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int Discount { get; set; }
        public int Condition { get; set; }
        public string Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Modify_Date { get;}
    }
}
