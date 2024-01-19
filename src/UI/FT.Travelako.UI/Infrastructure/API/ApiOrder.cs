using System;

namespace FT.Travelako.UI.Infrastructure.API
{
    public static class ApiCoupon
    {
        public static string GetCouponsByUserId(string baseUri, string userId)
        {
            return $"{baseUri}/GetCouponsByUserId/{userId}";
        }
    }
}