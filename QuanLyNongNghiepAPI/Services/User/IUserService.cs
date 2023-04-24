using QuanLyNongNghiepAPI.DataTransferObject;

namespace QuanLyNongNghiepAPI.Services.User
{
    public interface IUserService
    {
        public Task<List<Models.User>> GetAllUserAsync();
        public Task<Models.User?> GetAUser(int uid);
    }
}
