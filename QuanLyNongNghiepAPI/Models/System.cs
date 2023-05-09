using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNongNghiepAPI.Models
{
    [Table("System")]
    public class System
    {
        [Key]
        public int SystemID { get; set; }
        [Required]
        public string Address { get; set; } = string.Empty;
        public string? Location { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Symbol { get; set; } = string.Empty;
        public DateTime UpdateAt { get; set; }
        public int AreaID { get; set; }
        public Area Area { get; set; } = null!;
    }
}
