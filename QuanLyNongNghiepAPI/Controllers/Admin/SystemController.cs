using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyNongNghiepAPI.DataTransferObject.ServerToClient;
using QuanLyNongNghiepAPI.DataTransferObject;
using QuanLyNongNghiepAPI.Services.System;
using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.SystemDTOs;

namespace QuanLyNongNghiepAPI.Controllers.Admin
{
    [ApiController]
    [Route("API/Admin/[controller]")]
    public class SystemController
    {
        private readonly ISystemService _systemService;


        public SystemController(ISystemService systemService)
        {
            _systemService = systemService;

        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetSystem/{systemId}")]
        public async Task<IActionResult> GetSystem(int systemId)
        {
            try
            {
                var result = await _systemService.Get(systemId);
                return result != null ? new OkObjectResult(new APIResponse<Models.System?>(result, "success", true)) : new NotFoundResult();
            }
            catch
            {
                return new BadRequestResult();
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetSystems")]
        public async Task<IActionResult> GetSystems(int pageNumber, int pageSize)
        {
            try
            {
                var result = await _systemService.GetSystems(pageNumber, pageSize);
                return new OkObjectResult(new APIResponse<PaginatedListModel<Models.System>>(result, "success", true));
            }
            catch
            {
                return new BadRequestResult();
            }

        }



        [Authorize(Roles = "Admin")]
        [HttpPost("AddSystem")]
        public async Task<IActionResult> AddSystem([FromBody] AddSystemModel addSystemModel)
        {

            if (string.IsNullOrEmpty(addSystemModel.Name))
            {
                return new BadRequestObjectResult(new APIResponse<string>(null, "Tên không được để trống.", false));
            }


            try
            {
                bool isAdded = await _systemService.Add(addSystemModel);
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
        [HttpPost("UpdateSystem")]
        public async Task<IActionResult> UpdateSystem([FromBody] UpdateSystemModel updateSystemModel)
        {
            try
            {
                bool isUpdate = await _systemService.Update(updateSystemModel);
                if (isUpdate == true)
                {
                    return new OkObjectResult(new APIResponse<bool>(isUpdate, "Cập nhật thành công.", true));
                }
                else
                {
                    return new NotFoundObjectResult(new APIResponse<bool>(false, "Cập nhật thất bại.", false));
                }

            }
            catch(Exception e)
            {
                return new BadRequestObjectResult(new APIResponse<bool>(false, e.Message, false));
            }

        }




        [Authorize(Roles = "Admin")]
        [HttpPost("DeleteSystem")]
        public async Task<IActionResult> DeleteSystem([FromBody] DeleteSystemModel deleteSystemModel)
        {
            try
            {
                bool isDelete = await _systemService.Delete(deleteSystemModel);
                if (isDelete == true)
                {
                    return new OkObjectResult(new APIResponse<bool>(isDelete, "Xóa thành công.", true));
                }
                else
                {
                    return new OkObjectResult(new APIResponse<bool>(false, "Xóa thất bại.", false));
                }

            }
            catch(Exception e)
            {
                return new OkObjectResult(new APIResponse<bool>(false, e.Message, false));
            }

        }
    }
}
