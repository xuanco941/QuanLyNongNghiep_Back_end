using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyNongNghiepAPI.DataTransferObject;
using QuanLyNongNghiepAPI.DataTransferObject.GatewayDTOs;
using QuanLyNongNghiepAPI.Services.Gateway;
using QuanLyNongNghiepAPI.Services.User;

namespace QuanLyNongNghiepAPI.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IGatewayService _gatewayService;

        public GatewayController(IUserService userService, IGatewayService gatewayService)
        {
            _userService = userService;
            _gatewayService = gatewayService;
        }


        [Authorize]
        [HttpGet("GetGateways/{categoryId}")]
        public async Task<IActionResult> GetGateways(int categoryId)
        {
            int? userId = _userService.GetUserIDContext();
            if (userId == null)
            {
                return new UnauthorizedResult();
            }

            try
            {
                List<Models.Gateway>? objs = await _gatewayService.GetGateways((int)userId, categoryId);
                return new OkObjectResult(new APIResponse<List<Models.Gateway>>(objs, "success", true));

            }
            catch
            {
                return new OkObjectResult(new APIResponse<List<Models.Gateway>>(null, "Lỗi truy vấn database.", false));
            }
        }


        [Authorize]
        [HttpGet("GetAGateway/{gatewayId}")]
        public async Task<IActionResult> GetAGateway(int gatewayId)
        {
            int? userId = _userService.GetUserIDContext();
            if (userId == null)
            {
                return new UnauthorizedResult();
            }

            try
            {
                Models.Gateway? obj = await _gatewayService.GetAGateway((int)userId, gatewayId);
                return new OkObjectResult(new APIResponse<Models.Gateway>(obj, "success", true));

            }
            catch
            {
                return new OkObjectResult(new APIResponse<Models.Gateway>(null, "Lỗi truy vấn database.", false));
            }
        }




        [Authorize]
        [HttpPost("AddGateway")]
        public async Task<IActionResult> AddGateway([FromBody] AddGatewayModel addGateway)
        {
            int? userId = _userService.GetUserIDContext();
            if (userId == null)
            {
                return new UnauthorizedResult();
            }

            try
            {
                bool isUpdate = await _gatewayService.AddGateway((int)userId, addGateway);
                if (isUpdate == true)
                {
                    return new OkObjectResult(new APIResponse<bool>(isUpdate, "Thêm thành công.", true));
                }
                else
                {
                    return new OkObjectResult(new APIResponse<bool>(false, "Thêm không thành công.", false));
                }

            }
            catch
            {
                return new OkObjectResult(new APIResponse<bool>(false, "Lỗi truy vấn.", false));
            }

        }


        [Authorize]
        [HttpPost("UpdateGateway")]
        public async Task<IActionResult> UpdateGateway([FromBody] UpdateGatewayModel updateGateway)
        {
            int? userId = _userService.GetUserIDContext();
            if (userId == null)
            {
                return new UnauthorizedResult();
            }

            try
            {
                bool isUpdate = await _gatewayService.UpdateGateway((int)userId, updateGateway);
                if (isUpdate == true)
                {
                    return new OkObjectResult(new APIResponse<bool>(isUpdate, "Cập nhật thành công.", true));
                }
                else
                {
                    return new OkObjectResult(new APIResponse<bool>(false, "Cập nhật không thành công.", false));
                }

            }
            catch
            {
                return new OkObjectResult(new APIResponse<bool>(false, "Lỗi truy vấn.", false));
            }

        }



        [Authorize]
        [HttpPost("DeleteGateway")]
        public async Task<IActionResult> DeleteGateway([FromBody] DeleteGatewayModel deleteGateway)
        {
            int? userId = _userService.GetUserIDContext();
            if (userId == null)
            {
                return new UnauthorizedResult();
            }

            try
            {
                bool isUpdate = await _gatewayService.DeleteGateway((int)userId, deleteGateway);
                if (isUpdate == true)
                {
                    return new OkObjectResult(new APIResponse<bool>(isUpdate, "Xóa thành công.", true));
                }
                else
                {
                    return new OkObjectResult(new APIResponse<bool>(false, "Xóa không thành công.", false));
                }

            }
            catch
            {
                return new OkObjectResult(new APIResponse<bool>(false, "Lỗi truy vấn.", false));
            }

        }




    }
}
