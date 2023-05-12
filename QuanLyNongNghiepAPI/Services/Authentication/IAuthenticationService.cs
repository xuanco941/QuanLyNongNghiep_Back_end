using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer;
using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.UserDTOs;

namespace QuanLyNongNghiepAPI.Services.Authentication
{
    public interface IAuthenticationService
    {
        public Task<Models.User?> AuthenticateAsync(LoginModel login);
        public Task<Models.User?> RegisterAsync(RegisterModel register);
        public Task<Models.User?> ForgotPasswordAsync(ForgotPasswordModel forgotPassword);
        public Task<bool> ChangePasswordAsync(int userId, ChangePasswordModel changePassword);
        public string GenerateToken(Models.User user);
    }
}
