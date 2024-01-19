namespace FT.Travelako.UI.Infrastructure.API
{
    public static class ApiUser
    {
        public static string GetUserInfo(string baseUri, string userName) => $"{baseUri}?UserName={userName}";
        public static string GetAllUser(string baseUri) => $"{baseUri}/GetAllUser";
        public static string GetUserInfoById(string baseUri, string userId) => $"{baseUri}/GetUserById?Id={userId}";
        public static string UpdateUser(string baseUri) => $"{baseUri}";
        public static string DeleteUser(string baseUri, string userId) => $"{baseUri}?Id={userId}";
        public static string CreateUser(string baseUri) => $"{baseUri}";
        public static string UpdatePersonalizeUser(string basePersonalizeUri) => $"{basePersonalizeUri}";
        public static string GetPersonalizeUser(string basePersonalizeUri, string userId) => $"{basePersonalizeUri}?Id={userId}";
    }
}
