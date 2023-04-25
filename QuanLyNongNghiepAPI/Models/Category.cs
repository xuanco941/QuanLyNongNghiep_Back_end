using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNongNghiepAPI.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Symbol { get; set; } = "Assets//category.png";
        public int UserID { get; set; }
        public User User { get; set; }

    }
}
