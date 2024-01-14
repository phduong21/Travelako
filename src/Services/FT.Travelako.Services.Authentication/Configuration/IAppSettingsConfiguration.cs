namespace FT.Travelako.Services.Authentication.Configuration
{
    public interface IAppSettingsConfiguration
    {
        public string? SecretKey { get; set; }
        public string? RedisConnection { get; set; }
    }
}
