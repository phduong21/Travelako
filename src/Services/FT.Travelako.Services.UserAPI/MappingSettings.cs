using AutoMapper;
using FT.Travelako.Services.UserAPI.Models;
using FT.Travelako.Services.UserAPI.Models.DTOs;
using FT.Travelako.Services.UserAPI.Models.Requests;

namespace FT.Travelako.Services.UserAPI
{
    public class MappingSettings
    {
        public static MapperConfiguration RegisterMap()
        {
            var mappingConfig = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
