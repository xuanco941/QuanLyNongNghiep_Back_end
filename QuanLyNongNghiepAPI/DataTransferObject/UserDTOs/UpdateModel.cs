﻿namespace QuanLyNongNghiepAPI.DataTransferObject.UserDTOs
{
    public class UpdateModel
    {
        public string FullName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;

    }
}