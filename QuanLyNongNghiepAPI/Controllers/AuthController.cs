using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyNongNghiepAPI.DataTransferObject;
using QuanLyNongNghiepAPI.DataTransferObject.UserDTOs;
using QuanLyNongNghiepAPI.Models;
using QuanLyNongNghiepAPI.Services.Authentication;


namespace QuanLyNongNghiepAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController
    {

        private readonly ILogger<AuthController> _logger;
        private readonly IAuthenticationService _authenticationService;
        private readonly IConfiguration _config;


        public AuthController(ILogger<AuthController> logger, IAuthenticationService authenticationService, IConfiguration config)
        {
            _logger = logger;
            _authenticationService = authenticationService;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
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
                    return new OkObjectResult(new APIResponse<string>(null, "Tài khoản hoặc mật khẩu không chính xác.", true));
                }
            }
            catch
            {
                return new BadRequestObjectResult(new APIResponse<string>(null, "Lỗi, truy vấn thất bại.", false));
            }
        }


        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] LoginDTO login)
        {
            return new OkResult();
        }

    }
}
