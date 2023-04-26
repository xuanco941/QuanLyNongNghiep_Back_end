using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyNongNghiepAPI.DataTransferObject;
using QuanLyNongNghiepAPI.DataTransferObject.SensorDTOs;
using QuanLyNongNghiepAPI.Services.Sensor;
using QuanLyNongNghiepAPI.Services.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuanLyNongNghiepAPI.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ISensorService _sensorService;

        public SensorController(IUserService userService, ISensorService sensorService)
        {
            _userService = userService;
            _sensorService = sensorService;
        }


        [Authorize]
        [HttpGet("GetSensors/{gatewayId}")]
        public async Task<IActionResult> GetSensors(int gatewayId)
        {
            int? userId = _userService.GetUserIDContext();
            if (userId == null)
            {
                return new UnauthorizedResult();
            }

            try
            {
                List<Models.Sensor>? objs = await _sensorService.GetSensors((int)userId, gatewayId);
                return new OkObjectResult(new APIResponse<List<Models.Sensor>>(objs, "success", true));

            }
            catch
            {
                return new OkObjectResult(new APIResponse<List<Models.Sensor>>(null, "Lỗi truy vấn database.", false));
            }
        }



        [Authorize]
        [HttpGet("GetASensor/{sensorId}")]
        public async Task<IActionResult> GetASensor(int sensorId)
        {
            int? userId = _userService.GetUserIDContext();
            if (userId == null)
            {
                return new UnauthorizedResult();
            }

            try
            {
                Models.Sensor? obj = await _sensorService.GetASensor((int)userId, sensorId);
                return new OkObjectResult(new APIResponse<Models.Sensor>(obj, "success", true));

            }
            catch
            {
                return new OkObjectResult(new APIResponse<Models.Sensor>(null, "Lỗi truy vấn database.", false));
            }
        }



        [Authorize]
        [HttpPost("AddSensor")]
        public async Task<IActionResult> AddSensor([FromBody] AddSensorModel addSensor)
        {
            int? userId = _userService.GetUserIDContext();
            if (userId == null)
            {
                return new UnauthorizedResult();
            }

            try
            {
                bool isUpdate = await _sensorService.AddSensor((int)userId, addSensor);
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
        [HttpPost("UpdateSensor")]
        public async Task<IActionResult> UpdateSensor([FromBody] UpdateSensorModel updateSensor)
        {
            int? userId = _userService.GetUserIDContext();
            if (userId == null)
            {
                return new UnauthorizedResult();
            }

            try
            {
                bool isUpdate = await _sensorService.UpdateSensor((int)userId, updateSensor);
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
        [HttpPost("DeleteSensor")]
        public async Task<IActionResult> DeleteSensor([FromBody] DeleteSensorModel deleteSensor)
        {
            int? userId = _userService.GetUserIDContext();
            if (userId == null)
            {
                return new UnauthorizedResult();
            }

            try
            {
                bool isUpdate = await _sensorService.DeleteSensor((int)userId, deleteSensor);
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
