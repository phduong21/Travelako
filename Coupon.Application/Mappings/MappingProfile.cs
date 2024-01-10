using AutoMapper;
using Coupon.Application.Features.Coupon.Commands.CreateCoupon;
using Coupon.Application.Features.Coupon.Commands.UpdateCoupon;
using Coupon.Application.Features.Coupon.Queries.GetListCoupons;
using Coupon.Domain.Entities;

namespace Coupon.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCouponCommand,Coupons>()
                .ForMember(c => c.TimeExpried, cc => cc.MapFrom(ccc => new TimeSpan(ccc.TimeExpried,0,0,0))).ReverseMap();
            CreateMap<UpdateCouponCommand,Coupons>()
                .ForMember(c => c.TimeExpried, cc => cc.MapFrom(ccc => new TimeSpan(ccc.TimeExpried, 0, 0, 0))).ReverseMap();
            CreateMap<Coupons, CouponViewModel>().ReverseMap();
        }
    }
}
