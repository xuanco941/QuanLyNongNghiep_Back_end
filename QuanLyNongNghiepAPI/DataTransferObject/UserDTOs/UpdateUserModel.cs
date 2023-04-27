﻿namespace QuanLyNongNghiepAPI.DataTransferObject.UserDTOs
{
    public class UpdateUserModel
    {
        public string FullName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public byte[]? Avatar { get; set; }

    }
}
