using System;

namespace FT.Travelako.UI.Infrastructure.API
{
    public static class ApiCoupon
    {
        public static string GetUsersCouponsByUserId(string baseUri, string userId, string businessUserId)
        {
            return $"{baseUri}/GetUsersCouponsByUserId?userId={userId}&businessUserId={businessUserId}";
        }
    }
}