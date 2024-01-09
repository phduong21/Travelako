using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace FT.Travelako.Services.TravelAPI.Filter
{
    public class AuthorizeCouponFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context != null)
            {
                var cacheService = context.HttpContext.RequestServices.GetService<IDistributedCache>();
                var idUser = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "id");
                if (idUser is null)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
                try
                {
                    var bearerToken = context.HttpContext.Request.Headers["Authorization"].ToString().Remove(0, 7);
                    var data = cacheService.GetStringAsync("user-" + idUser.Value.ToString()).Result;
                    if (string.IsNullOrEmpty(data) || !data.Contains(bearerToken))
                    {
                        context.Result = new UnauthorizedResult();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
            }
            else
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}
