using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace QuanLyNongNghiepAPI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareCustom
    {
        private readonly RequestDelegate _next;

        public MiddlewareCustom(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareCustomExtensions
    {
        public static IApplicationBuilder UseMiddlewareCustom(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareCustom>();
        }
    }
}
