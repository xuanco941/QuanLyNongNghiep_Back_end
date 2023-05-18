using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNongNghiepAPI.Models
{
    [Table("SystemProcessNote")]
    public class SystemProcessNote
    {
        [Key]
        public int SystemProcessNoteID { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string? Message { get; set; } = string.Empty;
        public string NotificationType { get; set; } = "Normal";
        public bool IsDone { get; set; } = false;
        public DateTime CreateAt { get; set; }

        public int SystemProcessID { get; set; }
        public SystemProcess SystemProcess { get; set; } = null!;
    }
}
