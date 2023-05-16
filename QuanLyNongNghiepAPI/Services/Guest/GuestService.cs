using Microsoft.EntityFrameworkCore;
using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.UserDTOs;
using QuanLyNongNghiepAPI.Models;

namespace QuanLyNongNghiepAPI.Services.Guest
{
    public class GuestService : IGuestService
    {
        private readonly DatabaseContext _dbContext;

        public GuestService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Models.Guest?> Get(int id)
        {
            try
            {
                Models.Guest? u = await _dbContext.Guests.FirstOrDefaultAsync(u => u.GuestID == id);
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
                var existingUser = await _dbContext.Guests.FindAsync(idContext);

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
                var user = await _dbContext.Guests.FirstOrDefaultAsync(c => c.GuestID == idContext);
                if (user != null)
                {
                    _dbContext.Guests.Remove(user);
                }
                return await _dbContext.SaveChangesAsync() > 0;

            }
            catch
            {
                throw;
            }
        }

        public async Task<Models.Guest?> ForgotPassword(ForgotPasswordModel forgotPassword)
        {
            Random rand = new Random();
            string password = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                password = password + rand.Next(0, 10);
            }

            try
            {
                Models.Guest? user = _dbContext.Guests.FirstOrDefault(a => a.Username == forgotPassword.Username);
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
                Models.Guest? user = await _dbContext.Guests.FirstOrDefaultAsync(a => a.GuestID == userId);
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
            Models.Guest user = new Models.Guest()
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
