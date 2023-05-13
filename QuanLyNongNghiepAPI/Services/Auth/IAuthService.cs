using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer;

namespace QuanLyNongNghiepAPI.Services.Auth
{
    public interface IAuthService
    {
        public string GenerateToken(string id, string role);
        public Task<Models.User?> AuthenticateUser(LoginModel login);
        public Task<Models.Guest?> AuthenticateGuest(LoginModel login);
        public Task<Models.Admin?> AuthenticateAdmin(LoginModel login);
    }
}
