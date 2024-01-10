namespace Booking.API.Configuration
{
    public interface IAppSettingsConfiguration
    {
        public string? SecretKey { get; set; }
        public string? RedisConnection { get; set; }
    }
}
