using System.ComponentModel.DataAnnotations;

namespace FT.Travelako.Services.Authentication.Model
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public string? Personalization { get; set; }
        public string Role { get; set; }

        public User() { }

        public User(string user, string password, UserRoles role)
        {
            UserName = user;
            Password = password;
            Role = role.ToString();
        }
    }

    public enum UserRoles
    {
        Administrator,
        Business,
        User
    }
}
