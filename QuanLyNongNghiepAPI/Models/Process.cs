using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNongNghiepAPI.Models
{
    [Table("Process")]
    public class Process
    {
        [Key]
        public int ProcessID { get; set; }
        public DateTime CreateAt { get; set; }
        public string? Message { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public string NotificationType { get; set; } = "Normal";
        public bool IsDone { get; set; } = false;
        public int SystemProcessID { get; set; }
        public SystemProcess SystemProcess { get; set; } = null!;
    }
}
