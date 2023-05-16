using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNongNghiepAPI.Models
{
    [Table("UserArea")]
    public class UserArea
    {
        public int UserID { get; set; }
        public User User { get; set; } = null!;

        public int AreaID { get; set; }
        public Area Area { get; set; } = null!;
    }
}
