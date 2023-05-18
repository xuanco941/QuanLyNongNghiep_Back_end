namespace QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.SystemProcessDTOs
{
    public class AddSystemProcessModel
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string? Message { get; set; } = string.Empty;
        public string NotificationType { get; set; } = "Normal";

        public int SystemID { get; set; }
    }
}
