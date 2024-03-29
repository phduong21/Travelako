﻿using FT.Travelako.Common.Models;

namespace FT.Travelako.UI.Models.Users
{
    public class CreateUserModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public UserRoles Role { get; set; }
    }
}
