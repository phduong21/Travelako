using AutoMapper;
using FT.Travelako.Services.CouponAPI.Models;
using FT.Travelako.Services.CouponAPI.Models.DTOs;

namespace FT.Travelako.Services.CouponAPI
{
    public class MappingSettings
    {
        public static MapperConfiguration RegisterMap()
        {
            var mappingConfig = new MapperConfiguration(c =>
            {
                c.CreateMap<Coupon, CouponDTO>();
                c.CreateMap<CouponDTO, Coupon>();
            });

            return mappingConfig;
        }
    }
}
