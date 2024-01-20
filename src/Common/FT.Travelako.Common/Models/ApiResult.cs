namespace Booking.Application.Models
{
    public class ApiResult<T>(bool succeeded, IEnumerable<string> errors)
    {
        public T Result { get; set; }

        public bool IsSuccess { get; init; } = succeeded;

        public string Message { get; set; }

        public string[] Errors { get; init; } = errors.ToArray();

        public static ApiResult<T> Success()
        {
            return new ApiResult<T>(true, Array.Empty<string>());
        }

        public static ApiResult<T> Success(T value)
        {
            var res = new ApiResult<T>(true, Array.Empty<string>());
            res.Result = value;
            return res;
        }

        public static ApiResult<T> Failure(IEnumerable<string> errors)
        {
            return new ApiResult<T>(false, errors);
        }

        public static ApiResult<T> Failure(T value)
        {
            var res = new ApiResult<T>(false, Array.Empty<string>());
            res.Result = value;
            return res;
        }

        public static ApiResult<T> Failure()
        {
            return new ApiResult<T>(false, new List<string>());
        }

        public static ApiResult<T> Failure(string error)
        {
            return new ApiResult<T>(false, new List<string>() { error });
        }

        public static ApiResult<T> Success(string message)
        {
            var res = new ApiResult<T>(true, Array.Empty<string>());
            res.Message = message;
            return res;
        }
    }
}
