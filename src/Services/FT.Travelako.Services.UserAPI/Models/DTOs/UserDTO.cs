﻿namespace FT.Travelako.Services.UserAPI.Models.DTOs
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public List<string>? Personalization { get; set; }
        public string Role  { get; set; }
        public Guid Id { get; protected set; }
    }
}
