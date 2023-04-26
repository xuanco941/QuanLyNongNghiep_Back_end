using QuanLyNongNghiepAPI.DataTransferObject.UserDTOs;

namespace QuanLyNongNghiepAPI.Services.Authentication
{
    public interface IAuthenticationService
    {
        public Task<Models.User?> AuthenticateUserAsync(LoginModel login);
        public Task<Models.User?> RegisterUserAsync(RegisterModel register);
        public Task<Models.User?> ForgotPasswordAsync(ForgotPasswordModel forgotPassword);
        public Task<bool> ChangePasswordAsync(int userId, ChangePasswordModel changePassword);
        public string GenerateTokenForUser(Models.User user);
    }
}
