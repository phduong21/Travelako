namespace FT.Travelako.Common.Utility
{
    public class StaticData
    {
        public static string BaseCouponAPI { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            PATCH,
            DELETE
        }
    }
}
