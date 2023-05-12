using QuanLyNongNghiepAPI.Models;

namespace QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.UserDTOs
{
    public class UpdateUserModel
    {
        public string? FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public string? Avatar { get; set; } = string.Empty;
    }
}
