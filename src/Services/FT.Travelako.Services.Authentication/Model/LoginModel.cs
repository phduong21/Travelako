using System.ComponentModel.DataAnnotations;

namespace FT.Travelako.Services.Authentication.Model
{
    public class LoginModel
    {
        public LoginModel() { }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Password { get; set; }
    }
}
