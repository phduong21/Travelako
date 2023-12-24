namespace FT.Travelako.OcelotApiGw.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserRoles Role { get; set; }

        public User() { }

        public User(string user,string password, UserRoles role)
        {
            UserName = user;
            Password = password;
            Role = role;
        }
    }

    public enum UserRoles
    {
        Administrator,
        Business,
        User
    }
}
