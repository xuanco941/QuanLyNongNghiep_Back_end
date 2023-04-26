﻿namespace QuanLyNongNghiepAPI.DataTransferObject.GatewayDTOs
{
    public class AddGatewayModel
    {
        public string Address { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Symbol { get; set; } = "Assets//category.png";
        public int CategoryID { get; set; }
    }
}
