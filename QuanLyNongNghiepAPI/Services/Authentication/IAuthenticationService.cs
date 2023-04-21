using QuanLyNongNghiepAPI.DataTransferObject;

namespace QuanLyNongNghiepAPI.Services.Authentication
{
    public interface IAuthenticationService
    {
        public Task<Models.User?> AuthenticateUserAsync(LoginModel login);
        public string GenerateTokenForUser(Models.User user);
    }
}
