using Booking.Domain.Common;
using FT.Travelako.Common.Entities;
using System.Text.Json.Serialization;

namespace Booking.Domain.Entities
{
    public class Order : EntityBase
    {
        public string FullName { get; set; }
        public string UserEmail { get; set; }
        public string Phone { get; set; }
        public string TourName { get; set; }
        public int GuestSize { get; set; }
        public DateTime BookAt { get; set; }
        public decimal TotalCost { get; set; }
        public Status Status { get; set; }
        public Guid TravelId { get; set; }
        public Guid UserId { get; set; }
    }

    public enum Status
    {
        Draft,
        Payment,
        Ordered,
        Cancel
    }
}
