using Microsoft.EntityFrameworkCore;
using QuanLyNongNghiepAPI.Models;
using QuanLyNongNghiepAPI.Services.User;
using System.Security.Claims;

namespace QuanLyNongNghiepAPI.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IUserService _userService;

        public CategoryService(DatabaseContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        public async Task<bool> AddCategory(Models.Category category)
        {
            int? userId = _userService.GetUserIDContext();
            if (userId != null)
            {
                category.UserID = (int)userId;
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
            else
            {
                return false;
            }
        }
        public async Task<bool> UpdateCategory(Models.Category category)
        {
            try
            {
                int? userId = _userService.GetUserIDContext();
                if (userId != null)
                {

                    var existingCategory = await _dbContext.Categories
                    .Include(c => c.User)
                    .FirstOrDefaultAsync(c => c.CategoryID == category.CategoryID && c.UserID == userId);
                    if (existingCategory != null)
                    {
                        existingCategory.Name = category.Name;
                        existingCategory.Description = category.Description;
                        existingCategory.Symbol = category.Symbol;
                        return await _dbContext.SaveChangesAsync() > 0;
                    }
                    else
                    {
                        return false;
                    }
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
        public async Task<bool> DeleteCategory(int categoryID)
        {
            try
            {
                int? userId = _userService.GetUserIDContext();
                if (userId != null)
                {
                    var category = await _dbContext.Categories
                    .Include(c => c.User)
                    .FirstOrDefaultAsync(c => c.CategoryID == categoryID && c.UserID == userId);
                    if (category != null)
                    {
                        _dbContext.Categories.Remove(category);
                        return await _dbContext.SaveChangesAsync() > 0;
                    }
                    else
                    {
                        return false;
                    }
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
        public async Task<List<Models.Category>?> GetCategoriesOfUser()
        {
            try
            {
                int? userId = _userService.GetUserIDContext();
                if (userId != null)
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
