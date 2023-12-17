namespace FT.Travelako.Services.CouponAPI.Models
{
    public class GenericAPIResponse
    {

        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
