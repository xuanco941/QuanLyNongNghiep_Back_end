using QuanLyNongNghiepAPI.DataTransferObject.UserDTOs;

namespace QuanLyNongNghiepAPI.Services.AuthenticationUser
{
    public interface IAuthenticationUserService
    {
        public Task<Models.User?> AuthenticateAsync(LoginModel login);
        public Task<Models.User?> RegisterAsync(RegisterModel register);
        public Task<Models.User?> ForgotPasswordAsync(ForgotPasswordModel forgotPassword);
        public Task<bool> ChangePasswordAsync(int userId, ChangePasswordModel changePassword);
        public string GenerateToken(Models.User user);
    }
}
