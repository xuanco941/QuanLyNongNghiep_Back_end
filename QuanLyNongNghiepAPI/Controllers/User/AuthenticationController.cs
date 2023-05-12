using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyNongNghiepAPI.DataTransferObject;
using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer;
using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.UserDTOs;
using QuanLyNongNghiepAPI.Services.User;
using QuanLyNongNghiepAPI.Utils.Email;
using System.Text.RegularExpressions;

namespace QuanLyNongNghiepAPI.Controllers.User
{
    [ApiController]
    [Route("User/[controller]")]
    public class AuthenticationController
    {

        private readonly ILogger<AuthenticationController> _logger;
        private readonly ISendEmail _sendEmail;
        private readonly IUserService _userService;


        public AuthenticationController(ILogger<AuthenticationController> logger, ISendEmail sendEmail, IUserService userService)
        {
            _logger = logger;
            _sendEmail = sendEmail;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {

            if (string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password))
            {
                return new BadRequestObjectResult(new APIResponse<string>(null, "Tài khoản hoặc mật khẩu không được để trống.", false));
            }

            try
            {
                Models.User? user = await _userService.a(login);
                if (user != null)
                {
                    var tokenString = _authenticationService.GenerateToken(user);

                    return new OkObjectResult(new APIResponse<string>(tokenString, "Đăng nhập thành công", true));
                }
                else
                {
                    return new NotFoundObjectResult(new APIResponse<string>(null, "Tài khoản hoặc mật khẩu không chính xác.", false));
                }
            }
            catch
            {
                return new BadRequestObjectResult(new APIResponse<string>(null, "Lỗi hệ thống, vui lòng quay lại sau.", false));
            }
        }


        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel register)
        {

            if (string.IsNullOrEmpty(register.Username) || string.IsNullOrEmpty(register.Email))
            {
                return new BadRequestObjectResult(new APIResponse<string>(null, "Username hoặc Email không được để trống.", false));
            }

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (Regex.IsMatch(register.Email, pattern))
            {
                try
                {
                    Models.User? user = await _authenticationService.RegisterAsync(register);
                    if (user != null)
                    {
                        bool flog = await _sendEmail.SendEmailFromGmail(user.Email, "LEANWAY", $"Đăng ký tài khoản thành công, mật khẩu của bạn là: {user.Password}.");
                        if (flog == true)
                        {
                            return new OkObjectResult(new APIResponse<bool>(true, $"Tạo tài khoản thành công, mật khẩu được gửi về email {user.Email}.", true));
                        }
                        else
                        {
                            await _userService.DeleteAUser(user.UserID);
                            return new NotFoundObjectResult(new APIResponse<bool>(false, "Lỗi hệ thống, vui lòng đăng ký lại sau.", false));
                        }
                    }
                    else
                    {
                        return new NotFoundObjectResult(new APIResponse<bool>(false, "Tạo tài khoản thất bại.", false));
                    }
                }
                catch
                {
                    return new BadRequestObjectResult(new APIResponse<bool>(false, "Tạo tài khoản thất bại.", false));
                }
            }
            else
            {
                return new BadRequestObjectResult(new APIResponse<bool>(false, "Email không hợp lệ", false));
            }

        }


        [AllowAnonymous]
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel forgotPassword)
        {
            if (string.IsNullOrEmpty(forgotPassword.Username))
            {
                return new BadRequestObjectResult(new APIResponse<string>(null, "Username không được để trống.", false));
            }

            try
            {
                Models.User? user = await _authenticationService.ForgotPasswordAsync(forgotPassword);
                if (user != null)
                {
                    bool flog = await _sendEmail.SendEmailFromGmail(user.Email, "LEANWAY", $"Đặt lại mật khẩu thành công, mật khẩu mới của bạn là: {user.Password}.");
                    if (flog == true)
                    {
                        return new OkObjectResult(new APIResponse<bool>(true, $"Tạo tài khoản thành công, mật khẩu mới đã được gửi về email {user.Email}.", true));
                    }
                    else
                    {
                        return new BadRequestObjectResult(new APIResponse<bool>(false, "Đặt lại mật khẩu thành công, mật khẩu chưa được gửi về email.", false));
                    }
                }
                else
                {
                    return new NotFoundObjectResult(new APIResponse<bool>(false, "Đặt lại mật khẩu thất bại.", false));
                }
            }
            catch
            {
                return new BadRequestObjectResult(new APIResponse<bool>(false, "Đặt lại mật khẩu thất bại.", false));
            }
        }

        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel changePassword)
        {

            int? userId = _userService.GetUserIDContext();
            if (userId == null)
            {
                return new UnauthorizedResult();
            }

            if (string.IsNullOrEmpty(changePassword.NewPassword))
            {
                return new BadRequestObjectResult(new APIResponse<string>(null, "Mật khẩu mới không được để trống.", false));
            }

            try
            {
                bool isChange = await _authenticationService.ChangePasswordAsync((int)userId, changePassword);

                if (isChange == true)
                {

                    return new OkObjectResult(new APIResponse<bool>(true, "Thay đổi mật khẩu thành công.", true));
                }
                else
                {
                    return new BadRequestObjectResult(new APIResponse<bool>(false, "Thay đổi mật khẩu thất bại.", false));
                }
            }
            catch
            {
                return new BadRequestObjectResult(new APIResponse<bool>(false, "Thay đổi mật khẩu thất bại.", false));
            }
        }

    }

}

