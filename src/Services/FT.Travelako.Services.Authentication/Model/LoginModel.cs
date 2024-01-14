using System.ComponentModel.DataAnnotations;

namespace FT.Travelako.Services.Authentication.Model
{
    public class LoginModel
    {
        public LoginModel() { }

        public string Id { get; set; }

        public string UserName { get; set; }

        public string Role { get; set; }
    }
}
