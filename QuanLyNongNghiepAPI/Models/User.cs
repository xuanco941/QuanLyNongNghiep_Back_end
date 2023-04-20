using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace QuanLyNongNghiepAPI.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [StringLength(100)]
        public string FullName { get; set; } = "";
        [Required]
        [StringLength(100)]
        public string Username { get; set; }
        [StringLength(100)]
        [Required]
        public string Password { get; set; }
        public string? Email { get; set; } = "abc@gmail.com";
        public string? PhoneNumber { get; set; } = "0123456789";

    }
}
