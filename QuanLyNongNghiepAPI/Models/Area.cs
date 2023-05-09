using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNongNghiepAPI.Models
{
    [Table("Area")]
    public class Area
    {
        [Key]
        public int AreaID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Symbol { get; set; } = string.Empty;
        public DateTime UpdateAt { get; set; }


    }
}
