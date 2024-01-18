using AutoMapper;
using Coupon.Application.Features.Coupon.Commands.CreateCoupon;
using Coupon.Application.Features.Coupon.Commands.UpdateCoupon;
using Coupon.Application.Features.Coupon.Queries.GetListCoupons;
using Coupon.Application.Features.CouponsUser.Commands.CreateUserCoupon;
using Coupon.Application.Features.CouponsUser.Commands.UpdateUserCoupon;
using Coupon.Application.Features.CouponsUser.Queries.GetListCouponByUserId;
using Coupon.Domain.Entities;

namespace Coupon.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Coupons,CreateCouponCommand>().ReverseMap();
            CreateMap<Coupons,UpdateCouponCommand>().ReverseMap();
            CreateMap<Coupons, CouponViewModel>().ReverseMap();
            CreateMap<CouponUser, CreateUserCouponCommand>().ReverseMap();
            CreateMap<CouponUser, UpdateUserCouponCommand>().ReverseMap();
            CreateMap<CouponUser, CouponUserModel>().ForMember(x => x.Id, cum => cum.MapFrom(y => y.Id))
                .ForMember(x => x.CouponId, cum => cum.MapFrom(y => y.CouponId))
                .ForMember(x => x.UserId, cum => cum.MapFrom(y => y.UserId))
                .ForMember(x => x.IsUsed, cum => cum.MapFrom(y => y.IsUsed));
            CreateMap<Coupons, CouponUserModel>()
                .ForMember(x => x.Title, cum => cum.MapFrom(y => y.Title))
                .ForMember(x => x.Code, cum => cum.MapFrom(y => y.Code))
                .ForMember(x => x.Discount, cum => cum.MapFrom(y => y.Discount))
                .ForMember(x => x.TimeExpried, cum => cum.MapFrom(y => y.TimeExpried));
        }
    }
}
