using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyNongNghiepAPI.DataTransferObject;
using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.SensorDTOs;
using QuanLyNongNghiepAPI.DataTransferObject.ServerToClient;
using QuanLyNongNghiepAPI.Services.Sensor;

namespace QuanLyNongNghiepAPI.Controllers.Admin
{
    [ApiController]
    [Route("API/Admin/[controller]")]
    public class SensorController
    {
        private readonly ISensorService _sensorService;


        public SensorController(ISensorService sensorService)
        {
            _sensorService = sensorService;

        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetSensor/{sensorId}")]
        public async Task<IActionResult> GetSensor(int sensorId)
        {
            try
            {
                var result = await _sensorService.Get(sensorId);
                return result != null ? new OkObjectResult(new APIResponse<Models.Sensor?>(result, "success", true)) : new NotFoundResult();
            }
            catch
            {
                return new BadRequestResult();
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetSensorsBySystemId/{systemID}")]
        public async Task<IActionResult> GetSensorsBySystemId(int systemID, int pageNumber, int pageSize)
        {
            try
            {
                var result = await _sensorService.GetSensorsBySystemId(pageNumber, pageSize, systemID);
                return new OkObjectResult(new APIResponse<PaginatedListModel<Models.Sensor>>(result, "success", true));
            }
            catch
            {
                return new BadRequestResult();
            }

        }


        [Authorize(Roles = "Admin")]
        [HttpPost("AddSensor")]
        public async Task<IActionResult> AddSensor([FromBody] AddSensorModel addSensorModel)
        {

            if (string.IsNullOrEmpty(addSensorModel.Name))
            {
                return new BadRequestObjectResult(new APIResponse<string>(null, "Tên không được để trống.", false));
            }


            try
            {
                bool isAdded = await _sensorService.Add(addSensorModel);
                if (isAdded == true)
                {
                    return new OkObjectResult(new APIResponse<bool>(isAdded, "Thêm thành công.", true));
                }
                else
                {
                    return new BadRequestObjectResult(new APIResponse<bool>(false, "Thêm không thành công.", false));
                }

            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(new APIResponse<bool>(false, e.Message, false));
            }

        }


        [Authorize(Roles = "Admin")]
        [HttpPost("UpdateSensor")]
        public async Task<IActionResult> UpdateSensor([FromBody] UpdateSensorModel updateSensorModel)
        {
            try
            {
                bool isUpdate = await _sensorService.Update(updateSensorModel);
                if (isUpdate == true)
                {
                    return new OkObjectResult(new APIResponse<bool>(isUpdate, "Cập nhật thành công.", true));
                }
                else
                {
                    return new NotFoundObjectResult(new APIResponse<bool>(false, "Cập nhật thất bại.", false));
                }

            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(new APIResponse<bool>(false, e.Message, false));
            }

        }




        [Authorize(Roles = "Admin")]
        [HttpPost("DeleteSensor")]
        public async Task<IActionResult> DeleteSensor([FromBody] DeleteSensorModel deleteSensorModel)
        {
            try
            {
                bool isDelete = await _sensorService.Delete(deleteSensorModel);
                if (isDelete == true)
                {
                    return new OkObjectResult(new APIResponse<bool>(isDelete, "Xóa thành công.", true));
                }
                else
                {
                    return new OkObjectResult(new APIResponse<bool>(false, "Xóa thất bại.", false));
                }

            }
            catch (Exception e)
            {
                return new OkObjectResult(new APIResponse<bool>(false, e.Message, false));
            }

        }
    }
}
