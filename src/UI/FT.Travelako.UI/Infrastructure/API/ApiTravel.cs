using System;

namespace FT.Travelako.UI.Infrastructure.API
{
    public static class ApiTravel
    {
        public static string GetTravelsByUserId(string baseUri, string userId)
        {
            return $"{baseUri}/GetTravel?userid={userId}";
        }

        public static string GetTravels(string baseUri)
        {
            return $"{baseUri}/GetTravel";
        }

        public static string GetTravelsByLocation(string baseUri, string location)
        {
            return $"{baseUri}/GetTravel?location={location}";
        }

        public static string GetTravelDetail(string baseUri, string TravelId)
        {
            return $"{baseUri}/GetTravel?id={TravelId}";
        }

        public static string DeleteTravel(string baseUri, string TravelId)
        {
            return $"{baseUri}/{TravelId}";
        }
    }
}