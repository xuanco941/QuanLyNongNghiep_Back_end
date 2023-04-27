namespace QuanLyNongNghiepAPI.DataTransferObject.CategoryDTOs
{
    public class AddCategoryModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte[]? Symbol { get; set; } 
    }
}
