using QuanLyNongNghiepAPI.DataTransferObject.CategoryDTOs;

namespace QuanLyNongNghiepAPI.Services.Category
{
    public interface ICategoryService
    {
        public Task<bool> AddCategory(int userId, AddCategoryModel addCategory);
        public Task<bool> UpdateCategory(int userId, UpdateCategoryModel updateCategory);
        public Task<bool> DeleteCategory(int userId, DeleteCategoryModel deleteCategory);
        public Task<List<Models.Category>?> GetCategories(int userId);
        public Task<Models.Category?> GetACategory(int userId, int categoryId);


    }
}
