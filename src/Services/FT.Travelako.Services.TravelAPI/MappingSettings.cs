using AutoMapper;
using FT.Travelako.Services.TravelAPI.Models;
using FT.Travelako.Services.TravelAPI.Models.DTOs;

namespace FT.Travelako.Services.TravelAPI
{
    public class MappingSettings
    {
        public static MapperConfiguration RegisterMap()
        {
            var mappingConfig = new MapperConfiguration(c =>
            {
                c.CreateMap<Travel, GetTravelRequestDTO>();
                c.CreateMap<GetTravelRequestDTO, Travel>();
            });

            return mappingConfig;
        }
    }
}
