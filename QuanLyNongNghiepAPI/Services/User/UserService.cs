using Microsoft.EntityFrameworkCore;
using QuanLyNongNghiepAPI.Controllers;
using QuanLyNongNghiepAPI.DataTransferObject;
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

    }

}
