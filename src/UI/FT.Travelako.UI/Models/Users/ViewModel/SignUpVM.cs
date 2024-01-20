using FT.Travelako.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace FT.Travelako.UI.Models.Users.ViewModel
{
    public class SignUpVM
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        public string? Address { get; set; }

        [Display(Name = "Are you a travel seller?")]
        public bool IsTravelSeller { get; set; }

        [Display(Name = "Image URL. Only online urls are accepted")]
        public string? ImageUrl { get; set; }
    }
}
