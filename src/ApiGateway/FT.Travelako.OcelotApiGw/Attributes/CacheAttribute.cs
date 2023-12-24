using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;
using FT.Travelako.OcelotApiGw.Configuration;
using FT.Travelako.OcelotApiGw.Service;

namespace FT.Travelako.OcelotApiGw.Attributes
{
    public class CacheAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _timeToLiveSecond;
        public CacheAttribute(int timeToLiveSecond = 200)
        {
            _timeToLiveSecond = timeToLiveSecond;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // check cache exists
            var cacheConfiguration = context.HttpContext.RequestServices.GetRequiredService<RedisConfiguration>();

            if (!cacheConfiguration.Enabled)
            {
                await next();
                return;
            }

            var cacheService = context.HttpContext.RequestServices.GetRequiredService<IResponseCacheService>();

            var cacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request);
            var cacheResponse = await cacheService.GetCacheResponseAsync(cacheKey);

            if (!string.IsNullOrWhiteSpace(cacheResponse))
            {
                var contentResult = new ContentResult
                {
                    Content = cacheResponse,
                    ContentType = "application/json",
                    StatusCode = 200
                };
                context.Result = contentResult;
                return;
            }

            var executeContext = await next();
            if (executeContext.Result is ObjectResult objectResult)
                await cacheService.SetCacheResponseAsync(cacheKey, objectResult, TimeSpan.FromSeconds(_timeToLiveSecond));
        }

        private static string GenerateCacheKeyFromRequest(HttpRequest request)
        {
            var keyBuilder = new StringBuilder();
            keyBuilder.Append($"{request.Path}");
            foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
            {
                keyBuilder.Append($"|{key}-{value}");
            }
            return keyBuilder.ToString();
        }
    }
}
