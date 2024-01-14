using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Features.Order.Queries.GetOrderDetails
{
    public class OrderDetails
    {
        public string FullName { get; set; }
        public string UserEmail { get; set; }
        public string Phone { get; set; }
        public string TourName { get; set; }
        public int GuestSize { get; set; }
        public decimal TotalPrice { get; set; }
        public int Status { get; set; }
        public Guid TravelId { get; set; }
    }
}
