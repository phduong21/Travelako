using System;

namespace FT.Travelako.UI.Infrastructure.API
{
    public static class ApiOrder
    {
        public static string GetOrderByUserId(string baseUri, string userId)
        {
            return $"{baseUri}/get-orders/{userId}";
        }

        public static string CheckOutOrder(string baseUri)
        {
            return $"{baseUri}/check-out";
        }

        public static string DeleteOrder(string baseUri, string orderId)
        {
            return $"{baseUri}/{orderId}";
        }

        public static string ShipOrder(string baseUri)
        {
            return $"{baseUri}/ship";
        }
    }
}