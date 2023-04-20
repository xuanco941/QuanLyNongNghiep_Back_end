using Microsoft.EntityFrameworkCore;
using QuanLyNongNghiepAPI.Models;

namespace QuanLyNongNghiepAPI.Services.User
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _dbContext;

        public UserService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Models.User>>? GetAllUserAsync()
        {
            try
            {
                return _dbContext.Users.ToListAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
