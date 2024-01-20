namespace FT.Travelako.Services.UserAPI.Constants
{
    public static class UserConstants
    {
        public static class ErrorMessage
        {
            public static readonly string NullError = $"{0} cannot be null";
            public static readonly string UserNotFound = "Something went wrong. Cannot find the specified user or the user might be deactivated";
        }
        public const int MaximumPersonalization = 5;
    }
}
