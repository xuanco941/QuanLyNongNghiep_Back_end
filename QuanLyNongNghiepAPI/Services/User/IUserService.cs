using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.UserDTOs;

namespace QuanLyNongNghiepAPI.Services.User
{
    public interface IUserService
    {
        public Task<Models.User?> Get(int id);
        public Task<bool> Update(UpdateUserModel user, int idContext);
        public Task<bool> Delete(int idContext);
        public Task<Models.User?> ForgotPassword(ForgotPasswordModel forgotPassword);
        public Task<bool> ChangePassword(int userId, ChangePasswordModel changePassword);
        public Task<bool> Add(AddUserModel addUserModel);


    }
}
