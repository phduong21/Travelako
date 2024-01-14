using FT.Travelako.Common.Entities;
using System.ComponentModel.DataAnnotations;

namespace FT.Travelako.Services.UserAPI.Models
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public string? Personalization { get; set; }
        public string Role { get; set; }
    }
}
