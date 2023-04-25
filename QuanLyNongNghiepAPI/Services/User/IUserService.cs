using QuanLyNongNghiepAPI.DataTransferObject;
using QuanLyNongNghiepAPI.DataTransferObject.UserDTOs;

namespace QuanLyNongNghiepAPI.Services.User
{
    public interface IUserService
    {
        public Task<List<Models.User>> GetAllUserAsync();
        public Task<Models.User?> GetAUser(int uid);
        public Task<bool> Update(int uid, UpdateDTO updatedUser);
    }
}
