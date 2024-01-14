using AutoMapper;
using Coupon.Domain.Entities;
using FT.Travelako.Services.CouponAPI.Models.DTOs;

namespace FT.Travelako.Services.CouponAPI
{
    public class MappingSettings
    {
        public static MapperConfiguration RegisterMap()
        {
            var mappingConfig = new MapperConfiguration(c =>
            {
                c.CreateMap<Coupons, GetCouponRequestDTO>();
                c.CreateMap<GetCouponRequestDTO, Coupons>();
            });

            return mappingConfig;
        }
    }
}
