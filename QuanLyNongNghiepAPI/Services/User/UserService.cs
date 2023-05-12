using Microsoft.EntityFrameworkCore;
using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer;
using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.UserDTOs;
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


        public async Task<Models.User?> Get(int id)
        {
            try
            {
                Models.User? u = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserID == id);
                return u;
            }
            catch
            {
                throw;
            }
        }
        public async Task<Models.User?> Update(UpdateUserModel user, int idContext)
        {
            try
            {
                var existingUser = await _dbContext.Users.FindAsync(idContext);

                if (existingUser != null)
                {
                    existingUser.FullName = user.FullName;
                    existingUser.Email = user.Email;
                    existingUser.PhoneNumber = user.PhoneNumber;
                    existingUser.Address = user.Address;
                    existingUser.Avatar = user.Avatar;

                    await _dbContext.SaveChangesAsync();
                    return existingUser;
                }
                else
                {
                    return existingUser;
                }
            }
            catch
            {
                return null;
            }
        }
        public async Task<bool> Delete(int idContext)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(c => c.UserID == idContext);
                if (user != null)
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


        public async Task<Models.User?> Authenticate(LoginModel login)
        {
            try
            {
                Models.User? user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Username == login.Username && u.Password == login.Password);
                return user;
            }
            catch
            {
                throw;
            }
        }



    }

}
