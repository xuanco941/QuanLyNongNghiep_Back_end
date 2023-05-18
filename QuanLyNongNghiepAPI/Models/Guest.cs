using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNongNghiepAPI.Models
{
    [Table("Guest")]
    public class Guest
    {
        [Key]
        public int GuestID { get; set; }
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
        public string? Email { get; set; } = string.Empty;
        [StringLength(20)]
        public string? PhoneNumber { get; set; } = string.Empty;
        [StringLength(300)]
        public string? Address { get; set; } = string.Empty;
        public string? Avatar { get; set; } = string.Empty;
        public string Role { get; set; } = "Guest";

        public int? SystemID { get; set; }
        public System? System { get; set; }

    }
}
