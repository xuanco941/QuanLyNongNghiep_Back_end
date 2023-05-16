﻿namespace QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.ProcessDTOs
{
    public class AddProcessModel
    {
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int Step { get; set; }
        public string? Message { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public string NotificationType { get; set; } = "Normal";
        public bool IsDone { get; set; } = false;
        public int SystemProcessID { get; set; }
    }
}