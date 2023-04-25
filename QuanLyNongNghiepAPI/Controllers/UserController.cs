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

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet("Info")]
        public async Task<IActionResult> Info()
        {
            try
            {
                Models.User? user = await _userService.GetInfoUserContext();
                return new OkObjectResult(new APIResponse<Models.User>(user, "success", true));

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
                bool isUpdate = await _userService.UpdateUserContext(update);
                if (isUpdate == true)
                {
                    return new OkObjectResult(new APIResponse<UpdateDTO>(update, "Cập nhật thành công.", true));
                }
                else
                {
                    return new OkObjectResult(new APIResponse<UpdateDTO>(null, "Cập nhật không thành công.", false));
                }

            }
            catch
            {
                return new OkObjectResult(new APIResponse<UpdateDTO>(null, "Lỗi truy vấn.", false));
            }

        }
    }
}
