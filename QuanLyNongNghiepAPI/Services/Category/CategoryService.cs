using Microsoft.EntityFrameworkCore;
using QuanLyNongNghiepAPI.DataTransferObject.CategoryDTOs;
using QuanLyNongNghiepAPI.Models;

namespace QuanLyNongNghiepAPI.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly DatabaseContext _dbContext;

        public CategoryService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddCategory(int userId, AddCategoryModel addCategory)
        {
            Models.Category category = new Models.Category();
            category.UserID = userId;
            category.Description = addCategory.Description;
            category.Name = addCategory.Name;
            category.Symbol = addCategory.Symbol;
            try
            {
                await _dbContext.Categories.AddAsync(category);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }

        }
        public async Task<bool> UpdateCategory(int userId, UpdateCategoryModel updateCategory)
        {
            try
            {
                var existingCategory = await _dbContext.Categories
                .FirstOrDefaultAsync(c => c.CategoryID == updateCategory.CategoryID);
                if (existingCategory != null && existingCategory.UserID == userId)
                {
                    existingCategory.Name = updateCategory.Name;
                    existingCategory.Description = updateCategory.Description;
                    existingCategory.Symbol = updateCategory.Symbol;
                    return await _dbContext.SaveChangesAsync() > 0;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }

        }
        public async Task<bool> DeleteCategory(int userId, DeleteCategoryModel deleteCategory)
        {
            try
            {
                var category = await _dbContext.Categories
                .FirstOrDefaultAsync(c => c.CategoryID == deleteCategory.CategoryID);
                if (category != null && category.UserID == userId)
                {
                    _dbContext.Categories.Remove(category);
                    return await _dbContext.SaveChangesAsync() > 0;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<Models.Category>?> GetCategoriesOfUser(int userId)
        {
            try
            {
                var category = await _dbContext.Categories.Where(c => c.UserID == userId).ToListAsync();
                if (category != null)
                {
                    return category;
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }
        }



    }
}
