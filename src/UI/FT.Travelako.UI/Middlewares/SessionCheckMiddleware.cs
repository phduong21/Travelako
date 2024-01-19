namespace FT.Travelako.UI.Middlewares
{
    public class SessionCheckMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionCheckMiddleware(RequestDelegate next, IHttpContextAccessor httpContextAccessor)
        {
            _next = next;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/requiretoken"))
            {
                var token = _httpContextAccessor.HttpContext?.Session.GetString("AccessToken");

                if (string.IsNullOrEmpty(token))
                {
                    // Redirect or handle the case where the value is not present
                    context.Response.Redirect("/User/Unauthorize");
                    return;
                }
            }

            await _next(context);
        }
    }
}
