using Microsoft.EntityFrameworkCore;
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
        public async Task<bool> Update(UpdateUserModel user, int idContext)
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
                }

                return await _dbContext.SaveChangesAsync() > 0;

            }
            catch
            {
                throw;
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
                }
                return await _dbContext.SaveChangesAsync() > 0;

            }
            catch
            {
                throw;
            }
        }

        public async Task<Models.User?> ForgotPassword(ForgotPasswordModel forgotPassword)
        {
            Random rand = new Random();
            string password = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                password = password + rand.Next(0, 10);
            }

            try
            {
                Models.User? user = _dbContext.Users.FirstOrDefault(a => a.Username == forgotPassword.Username);
                if (user != null)
                {
                    user.Password = password;
                }
                int num = await _dbContext.SaveChangesAsync();
                if (num > 0)
                {
                    return user;
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

        public async Task<bool> ChangePassword(int userId, ChangePasswordModel changePassword)
        {
            try
            {
                Models.User? user = await _dbContext.Users.FirstOrDefaultAsync(a => a.UserID == userId);
                if (user != null)
                {
                    user.Password = changePassword.NewPassword;
                }
                return await _dbContext.SaveChangesAsync() > 0;

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Add(AddUserModel addUserModel)
        {
            Models.User user = new Models.User()
            {
                FullName = addUserModel.FullName,
                Username = addUserModel.Username,
                Address = addUserModel.Address,
                Email = addUserModel.Email,
                PhoneNumber = addUserModel.PhoneNumber,
                Password = addUserModel.Password
            };

            try
            {
                await _dbContext.AddAsync(user);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                throw;
            }
        }



    }

}
