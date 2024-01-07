using Booking.Domain.Common;

namespace Booking.Domain.Entities
{
    public class Order : EntityBase
    {
        public decimal TotalCost { get; set; }
        public int Status { get; set; }
        public Guid TravelId { get; set; }
        public Guid UserId { get; set; }
    }
}
