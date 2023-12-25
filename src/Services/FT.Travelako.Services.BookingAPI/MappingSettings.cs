using AutoMapper;
using FT.Travelako.Services.BookingAPI.Models;
using FT.Travelako.Services.BookingAPI.Models.DTOs;

namespace FT.Travelako.Services.BookingAPI
{
    public class MappingSettings
    {
        public static MapperConfiguration RegisterMap()
        {
            var mappingConfig = new MapperConfiguration(c =>
            {
                c.CreateMap<Booking, GetBookingRequestDTO>();
                c.CreateMap<GetBookingRequestDTO, Booking>();
            });

            return mappingConfig;
        }
    }
}
