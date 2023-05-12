using System.Security.Claims;

namespace QuanLyNongNghiepAPI.Utils.Context
{
    public class HttpContextMethod : IHttpContextMethod
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public HttpContextMethod(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }
        public int? GetIDContext()
        {

            var httpContext = _httpContextAccessor.HttpContext;
            string? Id = null;
            if (httpContext != null && httpContext.User != null)
            {
                Id = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            }

            if (string.IsNullOrEmpty(Id) == false)
            {
                try
                {
                    return int.Parse(Id);
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
