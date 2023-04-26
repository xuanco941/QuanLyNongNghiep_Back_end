using Microsoft.EntityFrameworkCore;
using QuanLyNongNghiepAPI.DataTransferObject.UserDTOs;
using QuanLyNongNghiepAPI.Models;
using System.Security.Claims;

namespace QuanLyNongNghiepAPI.Services.User
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(DatabaseContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public int? GetUserIDContext()
        {
            
            var httpContext = _httpContextAccessor.HttpContext;
            string? userId = null;
            if (httpContext != null && httpContext.User != null)
            {
                userId = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            }

            if (string.IsNullOrEmpty(userId) == false)
            {
                try
                {
                    return int.Parse(userId);
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public async Task<Models.User?> GetInfoUserContext()
        {
            try
            {
                int? userID = GetUserIDContext();
                if (userID != null)
                {
                    Models.User? u = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserID == userID);
                    return u;
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateUserContext(UpdateModel updatedUser)
        {
            try
            {
                int? userID = GetUserIDContext();
                if (userID != null)
                {
                    var existingUser = await _dbContext.Users.FindAsync(userID);

                    if (existingUser != null)
                    {
                        existingUser.FullName = updatedUser.FullName;
                        existingUser.Username = updatedUser.Username;
                        existingUser.Email = updatedUser.Email;
                        existingUser.PhoneNumber = updatedUser.PhoneNumber;
                        existingUser.Address = updatedUser.Address;
                        existingUser.Avatar = updatedUser.Avatar;

                        await _dbContext.SaveChangesAsync();
                        return true;
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
        public async Task<bool> DeleteAUser(int userId)
        {
            try
            {
                var user = await _dbContext.Users
                .FirstOrDefaultAsync(c => c.UserID == userId);
                if (user != null )
                {
                    _dbContext.Users.Remove(user);
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



    }

}
