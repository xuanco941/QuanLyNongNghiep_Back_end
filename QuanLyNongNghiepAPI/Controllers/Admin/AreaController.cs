using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyNongNghiepAPI.DataTransferObject;
using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.AreaDTOs;
using QuanLyNongNghiepAPI.DataTransferObject.ServerToClient;
using QuanLyNongNghiepAPI.Services.Area;

namespace QuanLyNongNghiepAPI.Controllers.Admin
{
    [ApiController]
    [Route("API/Admin/[controller]")]
    public class AreaController
    {
        private readonly IAreaService _areaService;


        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;

        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetArea/{areaId}")]
        public async Task<IActionResult> GetArea(int areaId)
        {
            try
            {
                var result = await _areaService.Get(areaId);
                return result != null ? new OkObjectResult(new APIResponse<Models.Area?>(result, "success",true)) : new NotFoundResult();
            }
            catch
            {
                return new BadRequestResult();
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetAreas")]
        public async Task<IActionResult> GetAreas(int pageNumber, int pageSize)
        {
            try
            {
                var result = await _areaService.GetAreas(pageNumber,pageSize);
                return new OkObjectResult(new APIResponse<PaginatedListModel<Models.Area>>(result, "success", true));
            }
            catch
            {
                return new BadRequestResult();
            }

        }



        [Authorize(Roles = "Admin")]
        [HttpPost("AddArea")]
        public async Task<IActionResult> AddArea([FromBody] AddAreaModel addAreaModel)
        {

            if (string.IsNullOrEmpty(addAreaModel.Name))
            {
                return new BadRequestObjectResult(new APIResponse<string>(null, "Tên không được để trống.", false));
            }


            try
            {
                bool isAdded = await _areaService.Add(addAreaModel);
                if (isAdded == true)
                {
                    return new OkObjectResult(new APIResponse<bool>(isAdded, "Thêm thành công.", true));
                }
                else
                {
                    return new BadRequestObjectResult(new APIResponse<bool>(false, "Thêm không thành công.", false));
                }

            }
            catch(Exception e)
            {
                return new BadRequestObjectResult(new APIResponse<bool>(false, e.Message, false));
            }

        }


        [Authorize(Roles = "Admin")]
        [HttpPost("UpdateArea")]
        public async Task<IActionResult> UpdateArea([FromBody] UpdateAreaModel updateAreaModel)
        {
            try
            {
                bool isUpdate = await _areaService.Update(updateAreaModel);
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
        [HttpPost("DeleteArea")]
        public async Task<IActionResult> DeleteArea([FromBody] DeleteAreaModel deleteAreaModel)
        {
            try
            {
                bool isDelete = await _areaService.Delete(deleteAreaModel);
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
