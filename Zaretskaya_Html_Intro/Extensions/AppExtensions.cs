using Microsoft.AspNetCore.Builder;
using Zaretskaya_Html_Intro.Middleware;

namespace Zaretskaya_Html_Intro.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder UseFileLogging(this IApplicationBuilder app)
        {
          return app.UseMiddleware<LogMiddleware>();
        }
    }
}
