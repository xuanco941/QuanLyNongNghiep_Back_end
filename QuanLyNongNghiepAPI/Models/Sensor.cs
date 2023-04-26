using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNongNghiepAPI.Models
{
    [Table("Sensor")]
    public class Sensor
    {
        [Key]
        public int SensorID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public string Symbol { get; set; } = "Assets//category.png";
        public DateTime CreateAt { get; set; }
        public int GatewayID { get; set; }
        public Gateway Gateway { get; set; } = null!;
    }
}
