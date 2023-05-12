using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer;
using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.UserDTOs;

namespace QuanLyNongNghiepAPI.Services.User
{
    public interface IUserService
    {
        public Task<Models.User?> Get(int id);
        public Task<Models.User?> Update(UpdateUserModel user, int idContext);
        public Task<bool> Delete(int idContext);
        public Task<Models.User?> Authenticate(LoginModel login);
    }
}
