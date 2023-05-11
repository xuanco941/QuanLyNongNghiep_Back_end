using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNongNghiepAPI.Models
{
    [Table("ProcessCondition")]
    public class ProcessCondition
    {
        [Key]
        public int ProcessConditionID { get; set; }
        public double ValueMin { get; set; }
        public double ValueMax { get; set; }
        public int SensorID { get; set; }
        public Sensor Sensor { get; set; } = null!;
        public int ProcessID { get; set; }
        public Process Process { get; set; } = null!;


    }
}
