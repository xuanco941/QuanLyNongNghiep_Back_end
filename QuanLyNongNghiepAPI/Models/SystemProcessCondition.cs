using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNongNghiepAPI.Models
{
    [Table("SystemProcessCondition")]
    public class SystemProcessCondition
    {
        [Key]
        public int SystemProcessConditionID { get; set; }
        public double? ValueMin { get; set; }
        public double? ValueMax { get; set; }
        public double? ValueAvg { get; set; }
        public int? Step { get; set; }
        public string? Description { get; set; } 
        public int SensorID { get; set; }
        public Sensor Sensor { get; set; } = null!;
        public int SystemProcessID { get; set; }
        public SystemProcess SystemProcess { get; set; } = null!;


    }
}
