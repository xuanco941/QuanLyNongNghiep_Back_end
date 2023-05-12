using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNongNghiepAPI.Models
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [StringLength(50)]
        public string? FullName { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;
        [StringLength(50)]
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;
        [StringLength(20)]
        public string? PhoneNumber { get; set; } = string.Empty;
        [StringLength(300)]
        public string? Address { get; set; } = string.Empty;
        public string? Avatar { get; set; } = string.Empty;
        public string Role { get; set; } = "Admin";

    }
}
