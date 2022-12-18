using Microsoft.AspNetCore.Localization;

namespace HakatonApi.Middleware
{
    public class LanguageMiddleware
    {
        private readonly RequestDelegate _next;

        public LanguageMiddleware(RequestDelegate next) =>
            _next = next;

        public Task Invoke(HttpContext httpContext)
        {
            // logic

            // load result from cache

            if (!httpContext.Request.Headers.ContainsKey("Language"))
            {
                throw new Exception("Language header missed!");
            }

           // RequestCulture.RequestLanguage = httpContext.Request.Headers["Language"];

            return _next(httpContext);

            // save result to cache
            //return Task.FromResult(result);
        }
    }
}
