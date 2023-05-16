namespace QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.SystemDTOs
{
    public class AddSystemModel
    {
        public string Address { get; set; } = string.Empty;
        public string? Location { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Symbol { get; set; } = string.Empty;
        public int AreaID { get; set; }
    }
}
