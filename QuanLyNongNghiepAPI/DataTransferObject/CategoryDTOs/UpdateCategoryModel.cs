namespace QuanLyNongNghiepAPI.DataTransferObject.CategoryDTOs
{
    public class UpdateCategoryModel
    {
        public int CategoryID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte[]? Symbol { get; set; }
    }
}
