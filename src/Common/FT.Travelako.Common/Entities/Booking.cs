namespace FT.Travelako.Common.Entities
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
        public Travel Travel { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}