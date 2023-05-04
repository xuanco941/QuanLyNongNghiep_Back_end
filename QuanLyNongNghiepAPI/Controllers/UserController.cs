using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyNongNghiepAPI.DataTransferObject;
using QuanLyNongNghiepAPI.DataTransferObject.UserDTOs;
using QuanLyNongNghiepAPI.Services.User;

namespace QuanLyNongNghiepAPI.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class UserController
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UserController(IUserService userService, IWebHostEnvironment hostEnvironment)
        {
            _userService = userService;
            _hostingEnvironment = hostEnvironment;
        }

        [Authorize]
        [HttpGet("Info")]
        public async Task<IActionResult> Info()
        {
            try
            {
                Models.User? user = await _userService.GetInfoUserContext();


                string imageDataUrl = string.Empty;

                if (user != null && string.IsNullOrEmpty(user.Avatar) == false)
                {
                    var imageBytes = System.IO.File.ReadAllBytes(user.Avatar);
                    var base64String = Convert.ToBase64String(imageBytes);
                    imageDataUrl = $"data:image/jpeg;base64,{base64String}";
                }


                var objectUser = user != null ? new { FullName = user.FullName, Username = user.Username, Email = user.Email, PhoneNumber = user.PhoneNumber, Address = user.Address, Avatar = imageDataUrl } : null;
                return new OkObjectResult(new APIResponse<object>(objectUser, "success", true));

            }
            catch (Exception e)
            {
                return new NotFoundObjectResult(new APIResponse<object>(null, e.Message, false));
            }

        }


        [Authorize]
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserModel update)
        {
            try
            {
                if (string.IsNullOrEmpty(update.Avatar) == false)
                {
                    var bytes = Convert.FromBase64String(update.Avatar);
                    var fileName = Guid.NewGuid().ToString() + ".jpg";
                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, $"uploads", fileName);
                    System.IO.File.WriteAllBytes(filePath, bytes);

                    update.Avatar = filePath;
                }

                bool isUpdate = await _userService.UpdateUserContext(update);
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
    }
}
