using Booking.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Application.Features.Coupon.Commands.UpdateCoupon
{
    public class UpdateCouponCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Code { get; set; }

        public int Discount { get; set; }

        public int Condition { get; set; }

        public string? LastModifiedBy { get; set; }

        public int TimeExpried { get; set; }
    }
}
