using FT.Travelako.Common.BaseModels;
using FT.Travelako.Services.UserAPI.Models.DTOs;

namespace FT.Travelako.Services.UserAPI.Extensions
{
    public static class ResponseExtension
    {
        public static GenericAPIResponse ErrorResponse(string message) => 
            new GenericAPIResponse { IsSuccess = false, Message = message };

        public static GenericAPIResponse SuccessResponse(object result) =>
            new GenericAPIResponse { IsSuccess = true, Result = result as UserDTO };
    }
}
