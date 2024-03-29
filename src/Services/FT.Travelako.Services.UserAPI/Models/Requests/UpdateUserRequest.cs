﻿using FT.Travelako.Common.BaseInterface;

namespace FT.Travelako.Services.UserAPI.Models.Requests
{
    public class UpdateUserRequest : IBaseRequestModel
    {
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
    }
}
