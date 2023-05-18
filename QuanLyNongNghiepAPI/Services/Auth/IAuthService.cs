using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer;

namespace QuanLyNongNghiepAPI.Services.Auth
{
    public interface IAuthService
    {
        public string GenerateToken(string id, string role);
        public Task<Models.User?> AuthenticateUser(LoginRequestModel login);
        public Task<Models.Guest?> AuthenticateGuest(LoginRequestModel login);
        public Task<Models.Admin?> AuthenticateAdmin(LoginRequestModel login);
    }
}
