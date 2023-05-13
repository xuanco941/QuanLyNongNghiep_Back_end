
namespace QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.UserDTOs
{
    public class AddUserModel
    {
        public string? FullName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? Avatar { get; set; } = string.Empty;
    }
}
