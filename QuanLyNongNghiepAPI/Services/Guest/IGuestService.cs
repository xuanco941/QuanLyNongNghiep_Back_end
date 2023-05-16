using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.UserDTOs;

namespace QuanLyNongNghiepAPI.Services.Guest
{
    public interface IGuestService
    {
        public Task<Models.Guest?> Get(int id);
        public Task<bool> Update(UpdateUserModel user, int idContext);
        public Task<bool> Delete(int idContext);
        public Task<Models.Guest?> ForgotPassword(ForgotPasswordModel forgotPassword);
        public Task<bool> ChangePassword(int userId, ChangePasswordModel changePassword);
        public Task<bool> Add(AddUserModel addUserModel);
    }
}
