using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyNongNghiepAPI.DataTransferObject;
using QuanLyNongNghiepAPI.DataTransferObject.CategoryDTOs;
using QuanLyNongNghiepAPI.DataTransferObject.UserDTOs;
using QuanLyNongNghiepAPI.Services.Category;
using QuanLyNongNghiepAPI.Services.User;

namespace QuanLyNongNghiepAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController
    {
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;


        public CategoryController(IUserService userService, ICategoryService categoryService)
        {
            _userService = userService;
            _categoryService = categoryService;
        }


        [Authorize]
        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            int? userId = _userService.GetUserIDContext();
            if(userId == null)
            {
                return new UnauthorizedResult();
            }

            try
            {
                List<Models.Category>? categories = await _categoryService.GetCategoriesOfUser((int)userId);
                return new OkObjectResult(new APIResponse<List< Models.Category>>(categories, "success", true));

            }
            catch
            {
                return new OkObjectResult(new APIResponse<List<Models.Category>>(null, "Lỗi truy vấn database.", false));
            }
        }


        [Authorize]
        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryModel addCategory)
        {
            int? userId = _userService.GetUserIDContext();
            if (userId == null)
            {
                return new UnauthorizedResult();
            }

            try
            {
                bool isUpdate = await _categoryService.AddCategory((int)userId, addCategory);
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
        [HttpPost("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryModel updateCategory)
        {
            int? userId = _userService.GetUserIDContext();
            if (userId == null)
            {
                return new UnauthorizedResult();
            }

            try
            {
                bool isUpdate = await _categoryService.UpdateCategory((int)userId, updateCategory);
                if (isUpdate == true)
                {
                    return new OkObjectResult(new APIResponse<bool>(isUpdate, "Cập nhật thành công.", true));
                }
                else
                {
                    return new OkObjectResult(new APIResponse<bool>(false, "Cập nhật thất bại.", false));
                }

            }
            catch
            {
                return new OkObjectResult(new APIResponse<bool>(false, "Lỗi truy vấn.", false));
            }

        }





        [Authorize]
        [HttpPost("DeleteCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] DeleteCategoryModel deleteCategory)
        {
            int? userId = _userService.GetUserIDContext();
            if (userId == null)
            {
                return new UnauthorizedResult();
            }

            try
            {
                bool isDelete = await _categoryService.DeleteCategory((int)userId, deleteCategory);
                if (isDelete == true)
                {
                    return new OkObjectResult(new APIResponse<bool>(isDelete, "Xóa thành công.", true));
                }
                else
                {
                    return new OkObjectResult(new APIResponse<bool>(false, "Xóa thất bại.", false));
                }

            }
            catch
            {
                return new OkObjectResult(new APIResponse<bool>(false, "Lỗi truy vấn.", false));
            }

        }



    }
}
