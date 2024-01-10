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
            CreateMap<Coupons, CreateCouponCommand>().ReverseMap();
            CreateMap<Coupons, UpdateCouponCommand>().ReverseMap();
            CreateMap<Coupons, CouponViewModel>().ReverseMap();
        }
    }
}
