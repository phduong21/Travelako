namespace FT.Travelako.Services.Authentication.Configuration
{
    public class AppSettingsConfiguration : IAppSettingsConfiguration
    {
        public string? SecretKey { get; set; }
        public string? RedisConnection { get ; set ; }
    }
}
