namespace QuanLyNongNghiepAPI.DataTransferObject.GatewayDTOs
{
    public class AddGatewayModel
    {
        public string Address { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public byte[]? Symbol { get; set; }
        public int CategoryID { get; set; }
    }
}
