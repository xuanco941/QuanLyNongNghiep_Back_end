using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyNongNghiepAPI.DataTransferObject;
using QuanLyNongNghiepAPI.DataTransferObject.UserDTOs;
using QuanLyNongNghiepAPI.Services.User;
using System.Security.Claims;

namespace QuanLyNongNghiepAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
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


        [Authorize]
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateDTO update)
        {
            try
            {
                var httpContext = _httpContextAccessor.HttpContext;
                if (httpContext != null && httpContext.User != null)
                {
                    var userId = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

                    if (userId != null)
                    {
                        bool isUpdate = await _userService.Update(int.Parse(userId), update);
                        if(isUpdate == true)
                        {
                            return new OkObjectResult(new APIResponse<UpdateDTO>(update, "Cập nhật thành công.", true));
                        }
                        else
                        {
                            return new OkObjectResult(new APIResponse<UpdateDTO>(null, "Cập nhật không thành công.", false));
                        }
                    }
                    else
                    {
                        return new OkObjectResult(new APIResponse<UpdateDTO>(null, "Người dùng không tồn tại.", false));
                    }
                }
                else
                {
                    return new OkObjectResult(new APIResponse<UpdateDTO>(null, "Người dùng không tồn tại.", false));
                }
            }
            catch
            {
                return new OkObjectResult(new APIResponse<UpdateDTO>(null, "Lỗi truy vấn.", false));
            }

        }
    }
}
