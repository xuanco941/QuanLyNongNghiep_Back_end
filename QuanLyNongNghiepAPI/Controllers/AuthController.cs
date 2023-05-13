using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer;
using QuanLyNongNghiepAPI.DataTransferObject;
using QuanLyNongNghiepAPI.Services.Auth;
using QuanLyNongNghiepAPI.DataTransferObject.ServerToClient;

namespace QuanLyNongNghiepAPI.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class AuthController
    {

        private readonly IAuthService _authService;



        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("User")]
        public async Task<IActionResult> User([FromBody] LoginModel login)
        {
            //kiểm tra tài khoản mật khẩu gửi xuống có rỗng hoặc null không
            if (string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password))
            {
                return new BadRequestObjectResult(new APIResponse<string>(null, "Tài khoản hoặc mật khẩu không được để trống.", false));
            }

            try
            {
                Models.User? user = await _authService.AuthenticateUser(login);
                if (user != null)
                {
                    var tokenString = _authService.GenerateToken(user.UserID.ToString(), user.Role);


                    return new OkObjectResult(new APIResponse<LoginResponseModel<Models.User>>(new LoginResponseModel<Models.User> { Token = tokenString, Info = user}, "Xác thực thành công", true));
                }
                else
                {
                    return new NotFoundObjectResult(new APIResponse<LoginResponseModel<Models.User>>(null, "Tài khoản hoặc mật khẩu không chính xác.", false));
                }
            }
            catch
            {
                return new BadRequestObjectResult(new APIResponse<LoginResponseModel<Models.User>>(null, "Lỗi hệ thống, vui lòng quay lại sau.", false));
            }
        }








        [AllowAnonymous]
        [HttpPost("Guest")]
        public async Task<IActionResult> Guest([FromBody] LoginModel login)
        {
            //kiểm tra tài khoản mật khẩu gửi xuống có rỗng hoặc null không
            if (string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password))
            {
                return new BadRequestObjectResult(new APIResponse<string>(null, "Tài khoản hoặc mật khẩu không được để trống.", false));
            }

            try
            {
                Models.Guest? user = await _authService.AuthenticateGuest(login);
                if (user != null)
                {
                    var tokenString = _authService.GenerateToken(user.GuestID.ToString(), user.Role);


                    return new OkObjectResult(new APIResponse<LoginResponseModel<Models.Guest>>(new LoginResponseModel<Models.Guest> { Token = tokenString, Info = user }, "Xác thực thành công", true));
                }
                else
                {
                    return new NotFoundObjectResult(new APIResponse<LoginResponseModel<Models.Guest>>(null, "Tài khoản hoặc mật khẩu không chính xác.", false));
                }
            }
            catch
            {
                return new BadRequestObjectResult(new APIResponse<LoginResponseModel<Models.Guest>>(null, "Lỗi hệ thống, vui lòng quay lại sau.", false));
            }
        }










        [AllowAnonymous]
        [HttpPost("Admin")]
        public async Task<IActionResult> Admin([FromBody] LoginModel login)
        {
            //kiểm tra tài khoản mật khẩu gửi xuống có rỗng hoặc null không
            if (string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password))
            {
                return new BadRequestObjectResult(new APIResponse<string>(null, "Tài khoản hoặc mật khẩu không được để trống.", false));
            }

            try
            {
                Models.Admin? user = await _authService.AuthenticateAdmin(login);
                if (user != null)
                {
                    var tokenString = _authService.GenerateToken(user.AdminID.ToString(), user.Role);


                    return new OkObjectResult(new APIResponse<LoginResponseModel<Models.Admin>>(new LoginResponseModel<Models.Admin> { Token = tokenString, Info = user }, "Xác thực thành công", true));
                }
                else
                {
                    return new NotFoundObjectResult(new APIResponse<LoginResponseModel<Models.Admin>>(null, "Tài khoản hoặc mật khẩu không chính xác.", false));
                }
            }
            catch
            {
                return new BadRequestObjectResult(new APIResponse<LoginResponseModel<Models.Admin>>(null, "Lỗi hệ thống, vui lòng quay lại sau.", false));
            }
        }
    }
}
