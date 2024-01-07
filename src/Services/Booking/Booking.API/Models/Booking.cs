using FT.Travelako.Common.Entities;

namespace Booking.API.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public long TotalCost { get; set; }
        public int Status { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public Guid TravelId { get; set; }
        public Guid UserId { get; set; }
    }
}