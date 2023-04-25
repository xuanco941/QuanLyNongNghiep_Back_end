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
        public string Location { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Symbol { get; set; } = "Assets//category.png";
        public DateTime CreateAt { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
