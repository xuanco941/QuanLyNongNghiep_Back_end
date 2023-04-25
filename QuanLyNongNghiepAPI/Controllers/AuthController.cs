using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyNongNghiepAPI.DataTransferObject;
using QuanLyNongNghiepAPI.DataTransferObject.UserDTOs;
using QuanLyNongNghiepAPI.Models;
using QuanLyNongNghiepAPI.Services.Authentication;
using QuanLyNongNghiepAPI.Utils;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace QuanLyNongNghiepAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController
    {

        private readonly ILogger<AuthController> _logger;
        private readonly IAuthenticationService _authenticationService;
        private readonly IConfiguration _config;
        private readonly ISendEmail _sendEmail;



        public AuthController(ILogger<AuthController> logger, IAuthenticationService authenticationService, IConfiguration config, ISendEmail sendEmail)
        {
            _logger = logger;
            _authenticationService = authenticationService;
            _config = config;
            _sendEmail = sendEmail;
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
                    return new OkObjectResult(new APIResponse<string>(null, "Tài khoản hoặc mật khẩu không chính xác.", false));
                }
            }
            catch
            {
                return new BadRequestObjectResult(new APIResponse<string>(null, "Lỗi, truy vấn thất bại.", false));
            }
        }


        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO register)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (Regex.IsMatch(register.Email, pattern))
            {
                try
                {
                    User? user = await _authenticationService.RegisterUserAsync(register);
                    if (user != null)
                    {
                        bool flog = await _sendEmail.SendEmailFromGmail(user.Email, "LEANWAY", $"Đăng ký tài khoản thành công, mật khẩu của bạn là: {user.Password}.");
                        if (flog == true)
                        {
                            return new OkObjectResult(new APIResponse<string>(null, "Tạo tài khoản thành công, mật khẩu được gửi về email.", true));
                        }
                        else
                        {
                            return new OkObjectResult(new APIResponse<string>(null, "Tạo tài khoản thành công, mật khẩu chưa được gửi về email.", false));
                        }
                    }
                    else
                    {
                        return new OkObjectResult(new APIResponse<string>(null, "Tạo tài khoản thất bại.", false));
                    }
                }
                catch
                {
                    return new OkObjectResult(new APIResponse<string>(null, "Tạo tài khoản thất bại.", false));
                }
            }
            else
            {
                return new OkObjectResult(new APIResponse<string>(null, "Email không hợp lệ", false));
            }
            
        }


        [AllowAnonymous]
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDTO forgotPassword)
        {
            try
            {
                User? user = await _authenticationService.ForgotPasswordAsync(forgotPassword);
                if (user != null)
                {
                    bool flog = await _sendEmail.SendEmailFromGmail(user.Email, "LEANWAY", $"Đặt lại mật khẩu thành công, mật khẩu mới của bạn là: {user.Password}.");
                    if (flog == true)
                    {
                        return new OkObjectResult(new APIResponse<string>(null, "Tạo tài khoản thành công, mật khẩu mới đã được gửi về email.", true));
                    }
                    else
                    {
                        return new OkObjectResult(new APIResponse<string>(null, "Đặt lại mật khẩu thành công, mật khẩu chưa được gửi về email.", false));
                    }
                }
                else
                {
                    return new OkObjectResult(new APIResponse<string>(null, "Đặt lại mật khẩu thất bại.", false));
                }
            }
            catch
            {
                return new OkObjectResult(new APIResponse<string>(null, "Đặt lại mật khẩu thất bại.", false));
            }
        }

        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO changePassword)
        {

            try
            {
                bool isChange = await _authenticationService.ChangePasswordAsync(changePassword);

                if (isChange == true)
                {

                    return new OkObjectResult(new APIResponse<string>(null, "Thay đổi mật khẩu thành công.", true));
                }
                else
                {
                    return new OkObjectResult(new APIResponse<string>(null, "Thay đổi mật khẩu thất bại.", false));
                }
            }
            catch
            {
                return new OkObjectResult(new APIResponse<string>(null, "Thay đổi mật khẩu thất bại.", false));
            }
        }

    }
}
