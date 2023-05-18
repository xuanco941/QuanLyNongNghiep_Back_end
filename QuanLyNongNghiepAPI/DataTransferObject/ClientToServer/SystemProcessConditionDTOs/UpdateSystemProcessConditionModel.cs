using QuanLyNongNghiepAPI.Models;

namespace QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.ProcessConditionDTOs
{
    public class UpdateSystemProcessConditionModel
    {
        public int SystemProcessConditionID { get; set; }
        public double? ValueMin { get; set; }
        public double? ValueMax { get; set; }
        public double? ValueAvg { get; set; }
        public int? Step { get; set; }
        public string? Description { get; set; }
        public int SensorID { get; set; }
        public int SystemProcessID { get; set; }
    }
}
