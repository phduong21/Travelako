using Booking.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Application.Features.CouponsUser.Commands.CreateUserCoupons
{
    public class CreateUserCouponsCommand : IRequest
    {
        public string BusinessId { get; set; }

        public string UserId { get; set; }

        public bool? IsUsed { get; set; }
        public int? CountBooking { get; set; }
    }
}
