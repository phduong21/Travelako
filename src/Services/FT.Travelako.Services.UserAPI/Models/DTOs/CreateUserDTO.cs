﻿using FT.Travelako.Common.Models;

namespace FT.Travelako.Services.UserAPI.Models.DTOs
{
    public class CreateUserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public string? Personalization { get; set; }
        public UserRoles Role { get; set; }
    }
}
