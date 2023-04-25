using QuanLyNongNghiepAPI.DataTransferObject;
using QuanLyNongNghiepAPI.DataTransferObject.UserDTOs;

namespace QuanLyNongNghiepAPI.Services.User
{
    public interface IUserService
    {
        public Task<Models.User?> GetInfoUserContext();
        public Task<bool> UpdateUserContext(UpdateDTO updatedUser);
        public int? GetUserIDContext();
    }
}
