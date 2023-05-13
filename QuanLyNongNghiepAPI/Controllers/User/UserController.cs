using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyNongNghiepAPI.DataTransferObject;
using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.UserDTOs;
using QuanLyNongNghiepAPI.Services.User;
using QuanLyNongNghiepAPI.Utils.Context;
using QuanLyNongNghiepAPI.Utils.Email;

namespace QuanLyNongNghiepAPI.Controllers.User
{
    [ApiController]
    [Route("API/[controller]")]
    
    public class UserController
    {
        private readonly IUserService _userService;
        private readonly IHttpContextMethod _httpContextMethod;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ISendEmail _sendEmail;


        public UserController(IUserService userService, IWebHostEnvironment hostEnvironment, IHttpContextMethod httpContextMethod,ISendEmail sendEmail)
        {
            _userService = userService;
            _hostingEnvironment = hostEnvironment;
            _httpContextMethod = httpContextMethod;
            _sendEmail = sendEmail;

        }

        [HttpGet("Info")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Info()
        {
            try
            {
                int idContext = _httpContextMethod.GetIDContext();

                Models.User? user = idContext != 0 ? await _userService.Get(idContext) : null;

                var objectUser = user != null ? new { user.FullName, user.Username, user.Email, user.PhoneNumber, user.Address, user.Avatar } : null;
                return new OkObjectResult(new APIResponse<object>(objectUser, "success", true));

            }
            catch (Exception e)
            {
                return new NotFoundObjectResult(new APIResponse<object>(null, e.Message, false));
            }

        }


        [HttpPost("Update")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Update([FromBody] UpdateUserModel update)
        {
            try
            {
                bool isUpdate = await _userService.Update(update,_httpContextMethod.GetIDContext());
                if (isUpdate == true)
                {
                    return new OkObjectResult(new APIResponse<UpdateUserModel>(update, "Cập nhật thành công.", true));
                }
                else
                {
                    return new BadRequestObjectResult(new APIResponse<UpdateUserModel>(null, "Cập nhật không thành công.", false));
                }

            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(new APIResponse<UpdateUserModel>(null, e.Message, false));
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
                Models.User? user = await _userService.ForgotPassword(forgotPassword);
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
            catch (Exception e)
            {
                return new BadRequestObjectResult(new APIResponse<bool>(false, e.Message, false));
            }
        }

        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel changePassword)
        {

            int idContext = _httpContextMethod.GetIDContext();
            if (idContext == 0)
            {
                return new UnauthorizedResult();
            }

            if (string.IsNullOrEmpty(changePassword.NewPassword))
            {
                return new BadRequestObjectResult(new APIResponse<string>(null, "Mật khẩu mới không được để trống.", false));
            }

            try
            {
                bool isChange = await _userService.ChangePassword(idContext,changePassword);

                if (isChange == true)
                {
                    return new OkObjectResult(new APIResponse<bool>(true, "Thay đổi mật khẩu thành công.", true));
                }
                else
                {
                    return new BadRequestObjectResult(new APIResponse<bool>(false, "Thay đổi mật khẩu thất bại.", false));
                }
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(new APIResponse<bool>(false, e.Message, false));
            }
        }


    }
}
