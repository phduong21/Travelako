namespace FT.Travelako.Services.UserAPI.Constants
{
    public static class UserConstants
    {
        public static class ErrorMessage
        {
            public static readonly string NullError = $"{0} cannot be null";
            public static readonly string UserNotFound = "Something went wrong. Cannot find the specified user or the user might be deactivated";
            public static readonly string WrongEmailFormat = "Something went wrong. Your email is not in valid format";
            public static readonly string DataExisted = $"{0} is already existed. Please use another information";
        }
        public const int MaximumPersonalization = 5;
        public static readonly string CreateSuccesfully = $"{0} cannot be null";
        public static readonly string UpdateSuccesfully = $"{0} cannot be null";
        public static readonly string DeleteSuccesfully = "Your account is deleted successfully";
    }
}
