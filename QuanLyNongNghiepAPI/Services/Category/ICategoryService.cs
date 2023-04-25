namespace QuanLyNongNghiepAPI.Services.Category
{
    public interface ICategoryService
    {
        public Task<bool> AddCategory(Models.Category category);
        public Task<bool> UpdateCategory(Models.Category category);
        public Task<bool> DeleteCategory(int categoryID);
        public Task<List<Models.Category>?> GetCategoriesOfUser();


    }
}
