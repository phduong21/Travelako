using System.ComponentModel.DataAnnotations;

namespace FT.Travelako.UI.Models.Users.ViewModel
{
    public class EditUserVM
    {
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
