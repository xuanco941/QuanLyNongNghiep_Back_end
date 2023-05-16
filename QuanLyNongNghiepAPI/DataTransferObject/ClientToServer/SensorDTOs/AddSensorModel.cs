namespace QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.SensorDTOs
{
    public class AddSensorModel
    {
        public string Address { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public string? Symbol { get; set; } = string.Empty;
        public string? Unit { get; set; } = string.Empty;
        public int SystemID { get; set; }
    }
}
