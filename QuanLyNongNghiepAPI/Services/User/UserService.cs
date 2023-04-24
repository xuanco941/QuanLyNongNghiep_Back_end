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
        public Models.User? GetAUser(int uid)
        {
            try
            {
                Models.User? u = _dbContext.Users.FirstOrDefault(u => u.UserID == uid);
                return u;
            }
            catch
            {
                throw;
            }
        }

    }

}
