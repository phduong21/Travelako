using Coupon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Application.Features.Coupon.Queries.GetListCoupons
{
    public class CouponViewModel
    {
        public CouponViewModel()
        {
                
        }

        public CouponViewModel(Coupons coupon)
        {
            Id = coupon.Id.ToString();
            Title = coupon.Title;
            Code = coupon.Code;
            Discount = coupon.Discount;
            Condition = coupon.Condition;
            TimeExpried = coupon.TimeExpried;
            CreateDate = coupon.CreatedDate;
        }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int Discount { get; set; }
        public int Condition { get; set; }
        public int TimeExpried { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
