using Microsoft.EntityFrameworkCore;
using QuanLyNongNghiepAPI.DataTransferObject.UserDTOs;
using QuanLyNongNghiepAPI.Models;

namespace QuanLyNongNghiepAPI.Services.User
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _dbContext;

        public UserService( DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        //get all user
        public async Task<List<Models.User>> GetAllUserAsync()
        {
            try
            {
                return await _dbContext.Users.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Models.User?> GetAUser(int uid)
        {
            try
            {
                Models.User? u = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserID == uid);
                return u;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Update(int uid ,UpdateDTO updatedUser)
        {
            try
            {
                var existingUser = _dbContext.Users.Find(uid);

                if (existingUser != null)
                {
                    existingUser.FullName = updatedUser.FullName;
                    existingUser.Username = updatedUser.Username;
                    existingUser.Email = updatedUser.Email;
                    existingUser.PhoneNumber = updatedUser.PhoneNumber;
                    existingUser.Address = updatedUser.Address;

                    await _dbContext.SaveChangesAsync();
                    return true;
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
