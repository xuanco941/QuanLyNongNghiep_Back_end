using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNongNghiepAPI.Models
{
    [Table("Gateway")]
    public class Gateway
    {
        [Key]
        public int GatewayID { get; set; }
        public string Address { get; set; } = string.Empty;
        public string? Location { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public byte[]? Symbol { get; set; }
        public DateTime CreateAt { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; } = null!;
    }
}
