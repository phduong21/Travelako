using Booking.Application.Models;

namespace FT.Travelako.Common.Mappings;

public static class MappingExtensions
{
    public static ApiResult<T> ToApiResponse<T>(this T value, bool isSuccess = true) => isSuccess ? ApiResult<T>.Success(value) : ApiResult<T>.Failure(value);
}
