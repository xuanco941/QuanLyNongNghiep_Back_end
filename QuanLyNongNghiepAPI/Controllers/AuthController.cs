using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyNongNghiepAPI.DataTransferObject;
using QuanLyNongNghiepAPI.Models;
using QuanLyNongNghiepAPI.Services;
using QuanLyNongNghiepAPI.Services.Authentication;
using QuanLyNongNghiepAPI.Services.User;
using System.Collections.Generic;

namespace QuanLyNongNghiepAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController
    {

        private readonly ILogger<AuthController> _logger;
        private readonly IAuthenticationService _authenticationService;


        public AuthController(ILogger<AuthController> logger, IAuthenticationService authenticationService, IConfiguration config)
        {
            _logger = logger;
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            try
            {
                User? user = await _authenticationService.AuthenticateUserAsync(login);
                if (user != null)
                {
                    var tokenString = _authenticationService.GenerateTokenForUser(user);

                    return new OkObjectResult(new APIResponse<string>(tokenString, "Đăng nhập thành công", true));
                }
                else
                {
                    return new OkObjectResult(new APIResponse<string>(null, "Đăng nhập thất bại.", true));
                }
            }
            catch
            {
                return new OkObjectResult(new APIResponse<string>(null, "Lỗi, truy vấn thất bại.", false));
            }
        }


        //[HttpGet("GetAllUser")]
        //public async Task<ActionResult<APIResponse<List<Models.User>>>> GetAllUser()
        //{
        //    try
        //    {
        //        List<Models.User> list = await _userService.GetAllUserAsync();
        //        return new APIResponse<List<User>>(list, "OK", true);
        //    }
        //    catch
        //    {
        //        return new APIResponse<List<User>>(null, "lỗi", true);
        //    }
        //}
    }
}
