using System.ComponentModel.DataAnnotations;

namespace FT.Travelako.Services.BookingAPI.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
    }
}
