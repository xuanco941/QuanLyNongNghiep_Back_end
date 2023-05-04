namespace QuanLyNongNghiepAPI.DataTransferObject.SensorDTOs
{
    public class UpdateSensorModel
    {
        public int? SensorID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
    }
}
