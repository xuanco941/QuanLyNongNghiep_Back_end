using QuanLyNongNghiepAPI.DataTransferObject.UserDTOs;

namespace QuanLyNongNghiepAPI.Services.Authentication
{
    public interface IAuthenticationService
    {
        public Task<Models.User?> AuthenticateUserAsync(LoginDTO login);
        public string GenerateTokenForUser(Models.User user);
    }
}
