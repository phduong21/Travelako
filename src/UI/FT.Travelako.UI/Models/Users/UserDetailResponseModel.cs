using FT.Travelako.Common.Models;

namespace FT.Travelako.UI.Models.Users
{
    public class UserDetailResponseModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public List<string>? Personalization { get; set; }
        public UserRoles Role { get; set; }
        public string? Id { get; set; }
        public string ResponseMessage { get; set; }
    }

    public class UserDetailResponseModelNew
    {
        public UserDetailResponseModelNew()
        {

        }

        public UserDetailResponseModelNew(UserDetailResponseViewModel user)
        {
            UserName = user.UserName;
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Address = user.Address;
            Image = user.Image;
            Personalization = !string.IsNullOrWhiteSpace(user.Personalization) ? user.Personalization.Split(',').ToList() : null;
			Role = user.Role;

        }
		public string Id { get; set; }
		public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public List<string>? Personalization { get; set; }
        public UserRoles Role { get; set; }
    }

    public class UserDetailResponseViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public string? Personalization { get; set; }
        public UserRoles Role { get; set; }
    }
}
