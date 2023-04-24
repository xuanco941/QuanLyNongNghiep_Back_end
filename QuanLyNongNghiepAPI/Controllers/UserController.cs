using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyNongNghiepAPI.DataTransferObject;
using QuanLyNongNghiepAPI.Models;
using QuanLyNongNghiepAPI.Services.User;
using System.Security.Claims;

namespace QuanLyNongNghiepAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(ILogger<UserController> logger, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        [HttpGet("Info")]
        public async Task<IActionResult> Info()
        {
            try
            {
                var httpContext = _httpContextAccessor.HttpContext;
                if (httpContext != null && httpContext.User != null)
                {
                    var userId = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                    if (userId != null)
                    {
                        Models.User? user = await _userService.GetAUser(int.Parse(userId));
                        return new OkObjectResult(new APIResponse<Models.User>(user, "success", true));
                    }
                    else
                    {
                        return new OkObjectResult(new APIResponse<Models.User>(null, "Không tồn tại", false));
                    }
                }
                else
                {
                    return new OkObjectResult(new APIResponse<Models.User>(null, "Không tồn tại", false));
                }
            }
            catch
            {
                return new OkObjectResult(new APIResponse<Models.User>(null, "Lỗi truy vấn database", false));
            }

        }
    }
}
