using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNongNghiepAPI.Models
{
    [Table("SystemProcess")]
    public class SystemProcess
    {
        [Key]
        public int SystemProcessID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public bool IsDone { get; set; } = false;
        public DateTime UpdateAt { get; set; }
        public int SystemID { get; set; }
        public System System { get; set; } = null!;
    }
}
