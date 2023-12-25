using AutoMapper;
using FT.Travelako.Services.UserAPI.Models;
using FT.Travelako.Services.UserAPI.Models.DTOs;

namespace FT.Travelako.Services.UserAPI
{
    public class MappingSettings
    {
        public static MapperConfiguration RegisterMap()
        {
            var mappingConfig = new MapperConfiguration(c =>
            {
                c.CreateMap<User, GetUserRequestDTO>();
                c.CreateMap<GetUserRequestDTO, User>();
            });

            return mappingConfig;
        }
    }
}
