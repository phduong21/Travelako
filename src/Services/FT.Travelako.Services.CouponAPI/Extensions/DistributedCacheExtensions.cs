using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace FT.Travelako.Services.CouponAPI.Extensions
{
    public static class DistributedCacheCExtensions
    {
        public static async Task SetRecordAsync<T>(this IDistributedCache cache, string recordId, T data, TimeSpan? absoluteExpireTime = null, TimeSpan? unuseExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions();
            options.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromMinutes(60);
            options.SlidingExpiration = unuseExpireTime;

            var jsonData = JsonSerializer.Serialize(data);
            await cache.SetStringAsync(recordId, jsonData, options);
        }

        public static async Task<T> GetRecordAsync<T>(this IDistributedCache cache, string recordId)
        {
            var jsonData = await cache.GetStringAsync(recordId);
            if (jsonData is null)
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(jsonData);
        }

        public static async Task RemoveRecordAsync(this IDistributedCache cache, string recordId)
        {
            await cache.RemoveAsync(recordId);
        }
    }
}
