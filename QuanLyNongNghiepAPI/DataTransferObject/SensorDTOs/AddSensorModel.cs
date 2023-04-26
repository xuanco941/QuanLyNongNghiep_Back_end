namespace QuanLyNongNghiepAPI.DataTransferObject.SensorDTOs
{
    public class AddSensorModel
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public string Symbol { get; set; } = "Assets//category.png";
        public int GatewayID { get; set; }
    }
}
