using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNongNghiepAPI.Models
{
    [Table("ResponseGateway")]
    public class ResponseGateway
    {
        [Key]
        public int ResponseGatewayID { get; set; }
        public DateTime CreateAt { get; set; }
        public int SystemID { get; set; }
        public System System { get; set; } = null!;

    }
}
