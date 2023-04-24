using Microsoft.EntityFrameworkCore;
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

    }

}
