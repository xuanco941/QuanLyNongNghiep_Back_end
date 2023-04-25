using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNongNghiepAPI.Models
{
    [Table("SensorData")]
    public class SensorData
    {
        [Key]
        public int SensorDataID { get; set; }
        public double Value { get; set; }
        public DateTime CreateAt { get; set; }
        public int SensorID { get; set; }
        public Sensor Sensor { get; set; }
    }
}
