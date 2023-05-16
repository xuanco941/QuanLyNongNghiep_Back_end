using QuanLyNongNghiepAPI.Models;

namespace QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.AreaDTOs
{
    public class UpdateAreaModel
    {
        public int AreaID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Symbol { get; set; } = string.Empty;
        public List<UserArea>? UserAreas { get; set; }
    }
}
