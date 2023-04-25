using QuanLyNongNghiepAPI.DataTransferObject.UserDTOs;

namespace QuanLyNongNghiepAPI.Services.Authentication
{
    public interface IAuthenticationService
    {
        public Task<Models.User?> AuthenticateUserAsync(LoginDTO login);
        public Task<Models.User?> RegisterUserAsync(RegisterDTO register);
        public Task<Models.User?> ForgotPasswordAsync(ForgotPasswordDTO forgotPassword);
        public Task<bool> ChangePasswordAsync(ChangePasswordDTO changePassword);
        public string GenerateTokenForUser(Models.User user);
    }
}
